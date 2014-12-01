using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouristApp_V3.Model;
using Windows.UI.Xaml;

namespace TouristApp_V3.ViewModel
{
    class MainViewModel : ObservableObject
    {
        #region Commands

        public ICommand NewOrder
        {
            get { return new DelegateCommand(MakeOrder); }
        }

        public ICommand IncOrder
        {
            get { return new DelegateCommand(IncreaseOrder); }
        }

        public ICommand DecOrder
        {
            get { return new DelegateCommand(DecreaseOrder); }
        }

        public void IncreaseOrder()
        {
            if (_selectedItem != null)
            {
                _selectedItem.OrderQuantity += 1;
                RaisePropertyChangedEvent("SelectedItem");
            }
        }

        public void DecreaseOrder()
        {
            if (_selectedItem != null)
            {
                _selectedItem.OrderQuantity -= 5;
                RaisePropertyChangedEvent("SelectedItem");
            }
        }

        public void MakeOrder()
        {
            int total = 0;

            foreach (Item item in _items)
            {
                if (item.OrderQuantity > 0)
                {
                    OrderViewModel.OrderItems.Add(new OrderItem(item.Name, item.Price, item.OrderQuantity));
                    total += item.Price * item.OrderQuantity;
                }
                OrderViewModel.Total.String = Convert.ToString(total) + " DKK";
            }
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
                return _foodCategories;
            }
        }
        public ObservableCollection<Item> Items
        {
            get //when xaml wants to get list of meals
            {
                ObservableCollection<Item> temp = new ObservableCollection<Item>(); //create new temporary list
                if (_selectedCategory != null) // check if something is selected, if its then skip
                {
                    foreach (Item item in _items) //loop through all meals, no matter what category are they
                    {
                        if (item.CategoryID == _selectedCategory.ID) //if the category matches with selected category
                        {
                            temp.Add(item); //add it to temporary list
                        }
                    }
                }
                return temp; //return temporary list, this will be displayed in app (mainpage.xaml second column)
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
                RaisePropertyChangedEvent("Items");
                //list of meals should be changed to show only meals in selected category
                //so we call RaisePropertyChanged with argument "Items" which refreshes everything binded to Items
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
                if (_selectedItem != null) //if selected item isnt null (if there is some item selected)
                {
                    _showDetail = true; //set showdetail to true, this means, that program will show 3 column on mainpage.xaml
                }
                else
                {
                    _showDetail = false;
                }
                RaisePropertyChangedEvent("ShowDetail");
                RaisePropertyChangedEvent("SelectedItem");
            }
        }
        #endregion

        #region Rest
        public MainViewModel()
        {

            _items = new ObservableCollection<Item>();
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

                var query2 = db.Table<Category>().OrderBy(c => c.Name);
                foreach (var _item in query2)
                {
                    _foodCategories.Add(new Category(_item.Name) { ID = _item.ID });
                }
            }

            _showDetail = false;
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
