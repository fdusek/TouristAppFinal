using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using TouristApp_V3.ViewModel;
using TouristApp_V3.Model;

namespace UnitTestLibrary1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IncreaseOrder()
        {
            MainViewModel t = new MainViewModel();
        }
        [TestMethod]
        public void DecreaseOrder()
        {
        }
    }
}
