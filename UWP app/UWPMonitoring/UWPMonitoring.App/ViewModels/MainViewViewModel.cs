using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UWPMonitoring.App.Utility;
using UWPMonitoring.DAL;
using UWPMonitoring.Models;

namespace UWPMonitoring.App.ViewModels
{
    public class MainViewViewModel
    {
        //Variabelen
        private INavigationService navigationService;
        private IRepository repository;

        //Properties
        public User User { get; set; }

        //Commands
        public ICommand LoginCommand { get; set; }

        //Constructor
        public MainViewViewModel(IRepository repository, INavigationService navigationService)
        {
            this.repository = repository;
            this.navigationService = navigationService;

            LoadCommands();
        }

        //Methode om de commands in te laden
        private void LoadCommands()
        {
            LoginCommand = new CustomCommand(Login, CanLogin);
        }

        //Methodes voor implementatie van LoginCommand
        private void Login(object obj)
        {

        }

        private bool CanLogin(object obj)
        {
            return true;
        }
    }
}
