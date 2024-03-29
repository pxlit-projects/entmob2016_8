﻿using HeadphoneDataApp.ViewModel;
using Microsoft.Practices.ServiceLocation;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using HeadphoneDataApp.View;

namespace HeadphoneDataApp
{
    public partial class App : Application
    {
        public static IAdapter Adapter;

        public static void SetAdapter(IAdapter adapter)
        {
            Adapter = adapter;
        }


        public App()
        {
            InitializeComponent();
            base.MainPage = ViewLocator.StartPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
