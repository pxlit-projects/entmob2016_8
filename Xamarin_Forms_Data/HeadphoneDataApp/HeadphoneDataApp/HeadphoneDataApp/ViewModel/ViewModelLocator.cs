/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:HeadphoneDataApp"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using Robotics.Mobile.Core.Bluetooth.LE;
using GalaSoft.MvvmLight.Views;

namespace HeadphoneDataApp.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private static IAdapter _adapter = App.Adapter;
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DeviceServiceViewModel>();
            //ServiceLocator.Default.Register<MainViewModel>(new MainViewModel(_adapter));
            //SimpleIoc.Default.Register<MainViewModel>();
        }

        public LoginViewModel Login
        {
            get
            {
                Messenger.Default.Send<IAdapter>(_adapter);
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public MainViewModel Main
        {
            get
            {
                //return ServiceLocator.Default.Register<MainViewModel>(new MainViewModel(_adapter));
                //Messenger.Default.Send<IAdapter>(_adapter);
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public DeviceServiceViewModel DeviceService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DeviceServiceViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

    }

}