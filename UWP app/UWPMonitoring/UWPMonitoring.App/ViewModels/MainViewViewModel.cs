using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UWPMonitoring.App.Service;
using UWPMonitoring.App.Utility;
using UWPMonitoring.Domain;

namespace UWPMonitoring.App.ViewModels
{
    public class MainViewViewModel : INotifyPropertyChanged
    {
        //Variabelen
        private INavigationService navigationService;
        private IDataService dataService;
        private string message;

        //Properties
        public User User { get; set; }
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                RaisePropertyChanged();
            }
        }

        //Commands
        public ICommand LoginCommand { get; set; }

        //Constructor
        public MainViewViewModel(INavigationService navigationService, IDataService dataService)
        {
            this.dataService = dataService;
            this.navigationService = navigationService;

            LoadCommands();

            User = new User();
        }

        //Methode om de commands in te laden
        private void LoadCommands()
        {
            LoginCommand = new CustomCommand(Login, CanLogin);
        }

        //Methodes voor implementatie van LoginCommand
        private void Login(object obj) 
        {
            try
            {
                if (dataService.Login(User))
                {
                    Messenger.Default.Send<User>(dataService.RetrievedUser); //Object van de ingelogde gebruiker doorsturen naar het volgende scherm
                    navigationService.NavigateTo("Overview"); //Naar het overzicht scherm gaan
                    User = new User();//Toegevoegd zodat het User object ook effectief leeg is als er word uitgelogd. Anders was deze niet leeg
                    Message = ""; //Bericht ook terug leegmaken zodat bij het uitloggen deze ook leeg is
                }
                else
                {
                    Message = dataService.Message;
                }
            }
            catch (Exception)
            {
                Message = "Er is een probleem met de connectie naar de server.";
            }

        }

        private bool CanLogin(object obj)
        {
            if (User.UserId != 0 && User.Password != "" && User.Password != null )
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        //Implementatie van de Interface 
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
