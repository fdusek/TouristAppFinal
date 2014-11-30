using TouristApp_V3.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.ComponentModel;


namespace TouristApp_V3.Model
{
    class OrderItem
    {
        private int _price;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public OrderItem(string name, int price, int quantity)
        {
            _price = price;
            _name = name;
            _quantity = quantity;
        }

        public override string ToString()
        {
            return _name + ";" + Convert.ToString(_price) + ";" + Convert.ToString(_quantity); 
        }
    }
}