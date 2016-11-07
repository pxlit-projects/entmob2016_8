using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UWPMonitoring.App.Utility;
using UWPMonitoring.DAL;
using UWPMonitoring.Domain;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace UWPMonitoring.App.ViewModels
{
    public class MainViewViewModel : INotifyPropertyChanged
    {
        //Variabelen
        private INavigationService navigationService;
        private IRepository repository;
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
        public MainViewViewModel(IRepository repository, INavigationService navigationService)
        {
            this.repository = repository;
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
            bool userExists =  repository.CheckIfUserIsValid(User.UserId);

            if (userExists)
            {
                User retrievedUser = repository.GetUserById(User.UserId);
                bool passwordCorrect = this.CheckUserPassword(retrievedUser);

                if (retrievedUser.Role == "admin")
                {
                    if (passwordCorrect)
                    {
                        Messenger.Default.Send<User>(retrievedUser); //Object van de ingelogde gebruiker doorsturen naar het volgende scherm
                        navigationService.NavigateTo("Overview"); //Naar het overzicht scherm gaan
                        User = new User();//Toegevoegd zodat het User object ook effectief leeg is als er word uitgelogd. Anders was deze niet leeg
                        Message = ""; //Bericht ook terug leegmaken zodat bij het uitloggen deze ook leeg is
                    }
                    else
                    {
                        this.Message = "Dit is geen geldig wachtwoord.";
                    }
                }
                else
                {
                    this.Message = "Deze gebruiker heeft geen admin rechten.";
                }
                
            }
            else
            {
                this.Message = "Het ingevulde id bestaat niet.";
            }

           
        }

        private bool CheckUserPassword(User retrievedUser)
        {
            string password = User.Password; //Wachtwoord die de gebruiker heeft ingegeven
            string salt = retrievedUser.Salt; //Salt van het opgehaalde user object
            string hashedPasswordWithSalt = Hasher.ConvertStringToHash(password, salt);
            bool passwordCorrect = hashedPasswordWithSalt.Equals(retrievedUser.Password);
            return passwordCorrect;

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
