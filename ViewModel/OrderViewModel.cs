using System;
using System.Collections.ObjectModel;
using TouristApp_V3.Model;
using TouristApp_V3.ObservableThings;
using Windows.Storage;

namespace TouristApp_V3.ViewModel
{
    class OrderViewModel : ObservableObject
    {

        #region Collections
        //PRIVATE DECLARATIONS OF COLLECTIONS

        //Collection of ordered items (used on OrderPage.xaml)
        private static ObservableCollection<OrderItem> _orderItems = new ObservableCollection<OrderItem>();

        //PUBLIC DECLARATIONS OF COLLECTIONS (can be accessed from xaml etc.)

        public static ObservableCollection<OrderItem> OrderItems
        {
            get { return _orderItems; }
            set{
                _orderItems = value;
            }
        }
        #endregion

        #region Rest
        private int _table;

        public int Table
        {
            get { return _table; }
            set { _table = value; }
        }

        private static ObservableString _total = new ObservableString();

        public static ObservableString Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public OrderViewModel()
        {
            RaisePropertyChangedEvent("Total");
        }

        private async void loadTable()
        {
            StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("table.txt");
            string text = await Windows.Storage.FileIO.ReadTextAsync(file);
            _table = Convert.ToInt32(text);
        }
        #endregion
    }
}
