using HeadPhoneDataApp;
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
        public static MainPage MainPage
        {
            get
            {
                return _mainPage ?? (_mainPage = new MainPage());
            }
        }
    }
}
