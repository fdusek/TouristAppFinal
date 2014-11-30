using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristApp_V3.Model
{
    class Table
    {
        private string _tableID;
   
        public string TableID
        {
            get { return _tableID; }
            set { _tableID = value; }
        }
        
        public Table(string TableID)
        {
            _tableID = TableID;
        }
    }
}
