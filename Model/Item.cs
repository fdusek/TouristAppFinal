using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace TouristApp_V3.Model
{
    class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        private int _categoryID;

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _price;

        private int _orderQuantity;

        public int OrderQuantity
        {
            get { return _orderQuantity; }
            set { _orderQuantity = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        private string _des;

        public string DES
        {
            get { return _des; }
            set { _des = value; }
        }

        public Brush BGBrush
        {
            get
            {
                if (_orderQuantity > 0)
                {
                    return new SolidColorBrush(Windows.UI.Color.FromArgb(100, 255, 255, 255));
                }
                else
                {
                    return new SolidColorBrush(Windows.UI.Color.FromArgb(0, 255, 255, 255));
                }
            }
        }
        public override string ToString()
        {
            return _name + ";" + Convert.ToString(_price) + ";" + Convert.ToString(_orderQuantity);
        }


        public Item()
        {
            _price = 0;
            _orderQuantity = 0;
        }

    }
}
