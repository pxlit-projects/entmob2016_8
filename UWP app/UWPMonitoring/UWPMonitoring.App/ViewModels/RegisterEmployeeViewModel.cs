﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UWPMonitoring.App.Service;
using UWPMonitoring.App.Utility;
using UWPMonitoring.Domain;
using Windows.UI.Popups;

namespace UWPMonitoring.App.ViewModels
{
    public class RegisterEmployeeViewModel : INotifyPropertyChanged
    {
        //Variabelen
        private INavigationService navigationService;
        private IDataService dataService;

        //Commands
        public CustomCommand RegisterCommand { get; set; }
        public CustomCommand BackCommand { get; set; }

        //Properties
        public User NewUser { get; set; }
        public bool IsTesting { get; set; }

        //Constructor
        public RegisterEmployeeViewModel(IDataService dataService, INavigationService navigationService)
        {
            this.dataService = dataService;
            this.navigationService = navigationService;
            NewUser = new User();

            LoadCommands();
        }

        //Methode om commando's in te laden
        private void LoadCommands()
        {
            RegisterCommand = new CustomCommand(Register, CanRegister);
            BackCommand = new CustomCommand(Back, CanGoBack);
        }

        //Implementatie van het register command
        private async void Register(object obj)
        {
            NewUser.Role = "user";
            string password = RandomPassword.Generate(12);
            NewUser.Salt = RandomPassword.Generate(30);
            NewUser.Password = Hasher.ConvertStringToHash(password, NewUser.Salt);
            NewUser.UserId = dataService.RegisterEmployee(NewUser);

            //Toegevoegd zodat bij het testen er geen dialog word weergegeven, dit gaf een exception
            if (!IsTesting)
            {
                var dialog = new MessageDialog("Id: " + NewUser.UserId + "\nPassword: " + password);
                dialog.Title = ("Created new employee: " + NewUser.FirstName + " " + NewUser.LastName);
                await dialog.ShowAsync();
            }
        }

        private bool CanRegister(object obj)
        {
            if (NewUser.FirstName != "" && NewUser.FirstName != null && 
                NewUser.LastName != "" && NewUser.LastName != null &&
                NewUser.Department != "" && NewUser.Department != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Implementatie van het back command
        private void Back(object obj)
        {
            NewUser = new User(); //Eventuele ingevulde waarden terug leeg maken
            navigationService.NavigateTo("Overview");
        }

        private bool CanGoBack(object obj)
        {
            return true;
        }

        //Implementatie van de interface INotifyPropertyChanged
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
