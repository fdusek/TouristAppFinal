using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristApp_V3.ViewModel;


namespace TouristApp_V3.ObservableThings
{
    class ObservableString : ObservableObject
    {
        private string _string;
        public string String
        {
            get { return _string; }
            set
            {
                _string = value;
                RaisePropertyChangedEvent("String");
            }
        }
    }
}
