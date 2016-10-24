using GalaSoft.MvvmLight.Messaging;
using HeadphoneDataApp.View;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeadphoneDataApp.ViewModel
{
    public class LoginViewModel
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
                    await App.Current.MainPage.Navigation.PushModalAsync(ViewLocator.MainPage);
                    Messenger.Default.Send<IAdapter>(adapter);
                }
                
            });
        }

        private void AdapterMessage(IAdapter obj)
        {
            this.adapter = obj;
        }

        public Command LoginCommand { get; private set; }
    }
}
