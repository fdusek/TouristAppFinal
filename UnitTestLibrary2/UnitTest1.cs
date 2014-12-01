using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestLibrary2
{
    [TestClass]
    public class UnitTest1
    {
        Object _selectedItem = new Object();

        [TestMethod]
        public void IncreaseOrder()
        {
            if (_selectedItem != null)
            {
                _selectedItem.OrderQuantity += 1;
                Assert.IsTrue(_selectedItem.OrderQuantity == 1);
            }
        }
        [TestMethod]
        public void DecreaseOrder()
        {
            if (_selectedItem != null)
            {
                _selectedItem.OrderQuantity -= 1;
                Assert.IsTrue(_selectedItem.OrderQuantity == -1);
            }
        }
    }

    class Object
    {
        private int _orderQuantity;
        public int OrderQuantity
        {
            get { return _orderQuantity; }
            set { _orderQuantity = value; }
        }
    }
}
