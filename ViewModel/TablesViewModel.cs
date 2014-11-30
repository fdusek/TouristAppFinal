using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TouristApp_V3.Model;

namespace TouristApp_V3.ViewModel
{
    class TablesViewModel : ObservableObject
    {
        #region Commands
        public ICommand SaveTable
        {
            get { return new DelegateCommand(SaveTableSettings); }
        }
        
        public void SaveTableSettings()
        {
            
        }
        #endregion 

        #region Collections
        //PRIVATE DECLARATIONS OF COLLECTIONS

        //Collection with tables (used on TableSetting.xaml page)
        private ObservableCollection<Table> _tables = new ObservableCollection<Table>();

        //PUBLIC DECLARATIONS OF COLLECTIONS (can be accessed from xaml etc.)
        public ObservableCollection<Table> Tables
        {
            get
            {
                return _tables;
            }
        }
        #endregion

        #region Selected tables
        private Table _selectedTable;

        public Table SelectedTable
        {
            get
            {
                return _selectedTable;
            }
            set
            {
                _selectedTable = value;
                _selectedTableID = Convert.ToInt32(value.TableID);
                RaisePropertyChangedEvent("SelectedTable");
            }
        }

        private static int _selectedTableID;
        public static int SelectedTableID
        {
            get
            {
                return _selectedTableID;
            }
        }

        #endregion

        #region The rest
        public TablesViewModel()
        {
            loadTables();
        }
        //property changed handler - when you call this method it will refresh specified data on xaml page, look down for examples
        public void loadTables()
        {
            //just create some dummy data, here should be loading from file
            for (int i = 0; i < 20; i++)
            {
                    _tables.Add(new Table(Convert.ToString(i)));
            }
            RaisePropertyChangedEvent("Tables");
        }
        #endregion
    }
}
