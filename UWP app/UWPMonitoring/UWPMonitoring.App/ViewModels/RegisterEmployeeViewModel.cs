using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UWPMonitoring.App.Utility;
using UWPMonitoring.DAL;
using UWPMonitoring.Domain;

namespace UWPMonitoring.App.ViewModels
{
    public class RegisterEmployeeViewModel : INotifyPropertyChanged
    {
        //Variabelen
        private IRepository repository;
        private INavigationService navigationService;

        //Commands
        public CustomCommand RegisterCommand { get; set; }
        public CustomCommand BackCommand { get; set; }

        //Properties
        public User NewUser { get; set; }

        //Constructor
        public RegisterEmployeeViewModel(IRepository repository, INavigationService navigationService)
        {
            this.repository = repository;
            this.navigationService = navigationService;

            LoadCommands();
        }

        //Methode om commando's in te laden
        private void LoadCommands()
        {
            RegisterCommand = new CustomCommand(Register, CanRegister);
            BackCommand = new CustomCommand(Back, CanGoBack);
        }

        //Implementatie van het register command
        private void Register(object obj)
        {
            
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
