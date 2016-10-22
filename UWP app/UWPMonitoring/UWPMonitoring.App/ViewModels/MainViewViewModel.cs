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
            //TODO: De username en password via een methode in de repo opsturen naar de backend en een boolean terug krijgen.
            //De gebruiker moet doorgestuurd worden naar het volgende scherm als zijn gegevens correct zijn
            bool userExists =  repository.CheckIfUserIsValid(User.UserId);

            if (userExists)
            {
                User retrievedUser = repository.GetUserById(User.UserId);
                //bool canLogin = this.CheckUser(retrievedUser);
            }

            Messenger.Default.Send<User>(User); //Object van de ingelogde gebruiker doorsturen naar het volgende scherm

            navigationService.NavigateTo("Overview");

            User = new User();//Toegevoegd zodat het User object ook effectief leeg is als er word uitgelogd. Anders was deze niet leeg
        }

        //private bool CheckUser(User user)
        //{
        //    string password = user.Password;
        //    string salt = user.Salt;
            
        //}

        //private string ConvertStringToHash(string password, string salt)
        //{
        //    var data = Encoding.UTF8.GetBytes(password + "" + salt);
        //    using (var shaM = new SHA512Managed())
        //    {

        //    }
        //}

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
