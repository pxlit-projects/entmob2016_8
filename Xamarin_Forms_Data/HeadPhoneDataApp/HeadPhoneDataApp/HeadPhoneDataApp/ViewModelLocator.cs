using HeadphoneDataApp.ViewModels;
using HeadPhoneDataApp;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeadphoneDataApp
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Current = new ViewModelLocator();
        private static IAdapter _adapter = App.Adapter;
        public MainPageViewModel _mainPageViewModel;


        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return _mainPageViewModel ?? (_mainPageViewModel = new MainPageViewModel(_adapter));
            }
        }




    }
}
