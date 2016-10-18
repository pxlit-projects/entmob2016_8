using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMonitoring.App.Utility;
using UWPMonitoring.DAL;
using UWPMonitoring.Domain;

namespace UWPMonitoring.App.ViewModels
{
    public class EmployeeOverviewViewModel
    {
        //Variabbelen
        private INavigationService navigationService;
        private IRepository repository;

        //Properties
        public User LoggedInUser { get; set; }
        public List<User> Employees { get; set; }

        //Constructor
        public EmployeeOverviewViewModel(INavigationService navigationService, IRepository repository)
        {
            this.navigationService = navigationService;
            this.repository = repository;

            LoadCommands();

            Messenger.Default.Register<User>(this, OnUserReceived);
        }

        //Methode om de ingelogde user in de property te laden
        private void OnUserReceived(User user)
        {
            //TODO: Extra gegevens van de ingelogde gebruiker ophalen via een methode van de repository
            LoggedInUser = user;
            LoggedInUser.FirstName = "Koen";
            LoggedInUser.LastName = "Castermans";
        }

        //Methode om de commands in te laden
        private void LoadCommands()
        {
           
        }
    }
}
