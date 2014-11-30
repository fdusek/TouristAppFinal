using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TouristApp_V3.Model;
using Windows.UI.Xaml;

namespace TouristApp_V3.ViewModel
{
    class EditViewModel : ObservableObject
    {
        #region Properties
        private int _cID;

        public int CID
        {
            get { return _cID; }
            set { _cID = value; }
        }

        private string _cName;

        public string CName
        {
            get { return _cName; }
            set { _cName = value; }
        }

        private int _iID;

        public int IID
        {
            get { return _iID; }
            set { _iID = value; }
        }

        private string _iName;

        public string IName
        {
            get { return _iName; }
            set { _iName = value; }
        }

        private string _iDescription;

        public string IDescription
        {
            get { return _iDescription; }
            set { _iDescription = value; }
        }

        private string _iImage;

        public string IImage
        {
            get { return _iImage; }
            set { _iImage = value; }
        }

        private int _iPrice;

        public int IPrice
        {
            get { return _iPrice; }
            set { _iPrice = value; }
        }

        private int _iCategory;

        public int ICategory
        {
            get { return _iCategory; }
            set { _iCategory = value; }
        }

        #endregion
        #region Commands
        public ICommand SaveCategory
        {
            get { return new DelegateCommand(_saveCategory); }
        }

        public void _saveCategory()
        {
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                try
                {
                    var existingCategory = (db.Table<Category>().Where(
                        c => c.ID == _cID)).SingleOrDefault();

                    if (existingCategory != null)
                    {
                        existingCategory.Name = _cName;
                        int success = db.Update(existingCategory);
                        _selectedCategory = existingCategory;
                    }
                    else
                    {
                        int success = db.Insert(new Category()
                        {
                            ID = _cID,
                            Name = _cName
                        });
                    }
                }
                catch (Exception e)
                {
                    new Windows.UI.Popups.MessageDialog("Couldn't save category to database :(" + Environment.NewLine + e.Message).ShowAsync();
                }
            }
            RaisePropertyChangedEvent("FoodCategories");
        }

        public ICommand SaveItem
        {
            get { return new DelegateCommand(_saveItem); }
        }

        public void _saveItem()
        {
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                try
                {
                    var existingItem = (db.Table<Item>().Where(
                        c => c.ID == _iID)).SingleOrDefault();

                    if (existingItem != null)
                    {
                        existingItem.Name = _iName;
                        existingItem.Image = _iImage;
                        existingItem.Price = _iPrice;
                        existingItem.DES = _iDescription;
                        existingItem.CategoryID = _iCategory;
                        _selectedItem = existingItem;
                        int success = db.Update(existingItem);
                    }
                    else
                    {
                        int success = db.Insert(new Item()
                        {
                            ID = _iID,
                            CategoryID = _iCategory,
                            DES = _iDescription,
                            Price = _iPrice,
                            Image = _iImage,
                            Name = _iName
                        });
                    }
                }
                catch (Exception e)
                {
                    new Windows.UI.Popups.MessageDialog("Couldn't save item to database :(" + Environment.NewLine + e.Message).ShowAsync();
                }
            }
            RaisePropertyChangedEvent("Items");
        }

        #endregion
        #region Collections
        //PRIVATE DECLARATIONS OF COLLECTIONS

        //Collection with food categories (first column on mainpage)
        private ObservableCollection<Category> _foodCategories = new ObservableCollection<Category>();
        //Collection with meals (first column on MainPage.xaml)
        //NOTE meals class should be changed to items, items class will be universal and it will be common for meals and drinks
        private ObservableCollection<Item> _items = new ObservableCollection<Item>();

        //PUBLIC DECLARATIONS OF COLLECTIONS (can be accessed from xaml etc.)

        public ObservableCollection<Category> FoodCategories
        {
            get
            {
                _foodCategories.Clear();
                using (var db = new SQLite.SQLiteConnection(App.DBPath))
                {
                    var query2 = db.Table<Category>().OrderBy(c => c.Name);
                    foreach (var _item in query2)
                    {
                        _foodCategories.Add(new Category(_item.Name) { ID = _item.ID });
                    }
                }
                return _foodCategories;
            }
        }
        public ObservableCollection<Item> Items
        {
            get //when xaml wants to get list of meals
            {
                _items.Clear();
                using (var db = new SQLite.SQLiteConnection(App.DBPath))
                {
                    var query = db.Table<Item>().OrderBy(c => c.Name);
                    foreach (var _item in query)
                    {
                        var tempItem = new Item()
                        {
                            ID = _item.ID,
                            CategoryID = _item.CategoryID,
                            DES = _item.DES,
                            Image = _item.Image,
                            Name = _item.Name,
                            OrderQuantity = 0,
                            Price = _item.Price
                        };
                        _items.Add(tempItem);
                    }
                }
                return _items;
            }
        }
        #endregion

        #region Selected items/categories
        private Category _selectedCategory;
        private Item _selectedItem;

        //new category was selected
        public Category SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;

                if (value != null)
                {
                    _cName = value.Name;
                    _cID = value.ID;
                    RaisePropertyChangedEvent("CID");
                    RaisePropertyChangedEvent("CName");
                    RaisePropertyChangedEvent("SelectedCategory");
                }
            }
        }

        //some meal was selected
        public Item SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                if (value != null)
                {

                    if (_selectedItem != null) //if selected item isnt null (if there is some item selected)
                    {
                        _showDetail = true; //set showdetail to true, this means, that program will show 3 column on mainpage.xaml
                    }
                    else
                    {
                        _showDetail = false;
                    }

                    _iCategory = value.CategoryID;
                    _iDescription = value.DES;
                    _iID = value.ID;
                    _iImage = value.Image;
                    _iName = value.Name;
                    _iPrice = value.Price;

                    RaisePropertyChangedEvent("ICategory");
                    RaisePropertyChangedEvent("IDescription");
                    RaisePropertyChangedEvent("IID");
                    RaisePropertyChangedEvent("IImage");
                    RaisePropertyChangedEvent("IName");
                    RaisePropertyChangedEvent("IPrice");

                    RaisePropertyChangedEvent("ShowDetail");
                    RaisePropertyChangedEvent("SelectedItem");
                }
            }
        }
        #endregion
        #region Rest
        public EditViewModel()
        {
        }


        private bool _showDetail;
        public object ShowDetail
        {
            get
            {
                if (_showDetail) //visibility isnt boolean but Visibility.Visible and Visibility.Collapsed so we translate boolean to these things by this if else statement
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
            set { }
        }
        #endregion
    }
}
