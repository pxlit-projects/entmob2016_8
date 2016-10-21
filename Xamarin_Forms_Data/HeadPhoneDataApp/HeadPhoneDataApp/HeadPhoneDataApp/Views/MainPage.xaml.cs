using HeadphoneDataApp;
using HeadphoneDataApp.ViewModels;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeadPhoneDataApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            
            InitializeComponent();
            this.BindingContext = ViewModelLocator.Current.MainPageViewModel;

        }
    }
}
