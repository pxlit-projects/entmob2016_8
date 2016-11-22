using GalaSoft.MvvmLight.Messaging;
using HeadphoneDataApp.Model;
using HeadphoneDataApp.Repository;
using HeadphoneDataApp.Utility;
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
        private IRepository repository;

        //Properties
        public string Username { get; set; }
        public string Password { get; set; }
        public string ValidationErrors { get; set; }
        public IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        //Commands
        public Command LoginCommand { get; set; }

        //Constructor
        public LoginViewModel()
        {
            //get the adapter via messenger
            Messenger.Default.Register<IAdapter>(this, AdapterMessage);
            repository = new HeadphoneDataApp.Repository.Repository();

            //Login
            LoginCommand = new Command(async () =>
            {
                //login controle
                if (CanLogin(this.Username, this.Password))
                {
                    try
                    {
                        //Controle als de user bestaat
                        int id = Convert.ToInt32(Username.Trim());
                        bool userExists = repository.CheckIfUserIsValid(id);
                       
                        if (userExists)
                        {
                            //Controle als het password juist is
                            User retrievedUser = repository.GetUserById(id);
                            bool passwordCorrect = this.CheckUserPassword(retrievedUser);
                            if (passwordCorrect)
                            {
                                //Open een andere view
                                await App.Current.MainPage.Navigation.PushModalAsync(ViewLocator.MainPage);

                                //Messenger aanspreken en User&Adapter doorsturen naar andere viewmodels
                                Messenger.Default.Send<IAdapter>(adapter);
                                Messenger.Default.Send<User>(retrievedUser);
                            }
                            else
                            {
                                ValidationErrors = "Password is incorrect";
                                OnPropertyChanged("ValidationErrors");
                            }
                        }
                        else
                        {
                            ValidationErrors = "UserId is Incorrect";
                            OnPropertyChanged("ValidationErrors");
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }             
                }
            });
        }

        //Methode voor het password te controleren 
        //  -> wordt opgeroepen bij de login command 
        private bool CheckUserPassword(User retrievedUser)
        {
            string password = Password.Trim(); //Wachtwoord die de gebruiker heeft ingegeven
            string salt = retrievedUser.Salt; //Salt van het opgehaalde user object
            string hashedPasswordWithSalt = Hasher.ConvertStringToHash(password, salt);
            bool passwordCorrect = hashedPasswordWithSalt.Equals(retrievedUser.Password);
            return passwordCorrect;
        }

        //Methode voor het checken als de inputvelden niet leeg zijn
        //  -> wordt opgeroepen bij de login command 
        public bool CanLogin(string Id, string Password)
        {
            //get
            {
                ValidationErrors = string.Empty;

                if (string.IsNullOrEmpty(Id))
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

        //Action wat wordt opgeroepen bij het registreren van de adapter 
        private void AdapterMessage(IAdapter obj)
        {
            this.adapter = obj;
        }

        //Implementatie van de interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        
 
       
    }
}
