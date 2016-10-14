using HeadPhoneDataApp;
using HeadPhoneDataApp.Views;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphoneDataApp
{
    public class ViewLocator
    {
        private static MainPage _mainPage;
        private static DevicePage _devicePage;

        public static MainPage MainPage
        {
            get
            {
                return _mainPage ?? (_mainPage = new MainPage());
            }
        }

        public static DevicePage DevicePage
        {
            get
            {
                return _devicePage ?? (_devicePage = new DevicePage());
            }
        }

      
    }
}
