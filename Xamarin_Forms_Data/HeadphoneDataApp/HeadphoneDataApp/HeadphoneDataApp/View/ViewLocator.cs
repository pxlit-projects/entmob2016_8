﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphoneDataApp.View
{
    static class ViewLocator
    {

        private static StartPage _startPage;
        private static MainPage _mainPage;
        private static DeviceServicePage _deviceServicePage;

        public static StartPage StartPage
        {
            get
            {
                return _startPage ?? (_startPage = new StartPage());
            }
        }

        public static MainPage MainPage
        {
            get
            {
                return _mainPage ?? (_mainPage = new MainPage());
            }
        }
        
        public static DeviceServicePage DeviceServicePage
        {
            get
            {
                return _deviceServicePage ?? (_deviceServicePage = new DeviceServicePage());
            }
        }
    }
}
