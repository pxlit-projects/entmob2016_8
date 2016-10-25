using GalaSoft.MvvmLight.Messaging;
using HeadphoneDataApp.View;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeadphoneDataApp.ViewModel
{
    public class LoginViewModel: INotifyPropertyChanged
    {
        private IAdapter adapter;

        public LoginViewModel()
        {
            //get the adapter via messenger
            Messenger.Default.Register<IAdapter>(this, AdapterMessage);

            this.LoginCommand = new Command(async () =>
            {
                //TO DO
                //login controle
                if (adapter==null)
                {
                    Debug.WriteLine("Geen bluetooth adapter gevonden");
                }
                else
                {
                    //TO DO
                    //if (CanLogin)
                    {
                        await App.Current.MainPage.Navigation.PushModalAsync(ViewLocator.MainPage);
                        Messenger.Default.Send<IAdapter>(adapter);
                    }
                    
                }
                
            });
        }

        public bool CanLogin
        {
            get
            {
                ValidationErrors = string.Empty;

                if (string.IsNullOrEmpty(Username))
                {
                    ValidationErrors = "Please enter a username.";
                    OnPropertyChanged("ValidationErrors");
                }
                if (string.IsNullOrEmpty(Password))
                {
                    ValidationErrors += "\nPlease enter a password.";
                    OnPropertyChanged("ValidationErrors");
                }
                return string.IsNullOrEmpty(ValidationErrors);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        private void AdapterMessage(IAdapter obj)
        {
            this.adapter = obj;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command LoginCommand { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ValidationErrors { get; private set; }
    }
}
