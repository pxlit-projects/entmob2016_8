using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMonitoring.App.Utility;
using UWPMonitoring.DAL;

namespace UWPMonitoring.App.ViewModels
{
    public class RegisterEmployeeViewModel
    {
        //Variabelen
        private IRepository repository;
        private INavigationService navigationService;

        //Commands

        //Properties
        
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

        }
    }
}
