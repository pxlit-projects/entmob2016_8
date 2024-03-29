﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using UWPMonitoring.App.Service;
using UWPMonitoring.App.Utility;
using UWPMonitoring.Domain;
using Windows.UI.Popups;

namespace UWPMonitoring.App.ViewModels
{
    public class EmployeeOverviewViewModel : INotifyPropertyChanged
    {
        //Variabbelen
        private INavigationService navigationService;
        private IDataService dataService;
        private List<User> employees;
        private User selectedEmployee;
        private List<User> omittedUsers = new List<User>();
        private string searchString;
        private int averageTime;
        private int minimumTime;
        private int maximumTime;
        private int totalLength;
        private DateTime lastSessionDate;

        //Commands
        public CustomCommand LogOutCommand { get; set; }
        public CustomCommand SearchCommand { get; set; }
        public CustomCommand ClearSearchCommand { get; set; }
        public CustomCommand LoadCommand { get; set; }
        public CustomCommand SelectionChangedCommand { get; set; }
        public CustomCommand NavigateToRegisterPageCommand { get; set; }

        //Properties
        public User LoggedInUser { get; set; }
        public List<User> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;
                RaisePropertyChanged();
            }
        }

        public User SelectedEmployee
        {
            get
            {
                return selectedEmployee;
            }
            set
            {
                selectedEmployee = value;
                RaisePropertyChanged();
            }
        }

        public string SearchString
        {
            get
            {
                return searchString;
            }
            set
            {
                searchString = value;
                RaisePropertyChanged();
            }
        }

        public int AverageTime
        {
            get
            {
                return averageTime;
            }
            set
            {
                averageTime = value;
                RaisePropertyChanged();
            }
        }

        public int MinimumTime
        {
            get
            {
                return minimumTime;
            }
            set
            {
                minimumTime = value;
                RaisePropertyChanged();
            }
        }

        public int MaximumTime
        {
            get
            {
                return maximumTime;
            }
            set
            {
                maximumTime = value;
                RaisePropertyChanged();
            }
        }

        public int TotalLength
        {
            get
            {
                return totalLength;
            }
            set
            {
                totalLength = value;
                RaisePropertyChanged();
            }
        }

        public DateTime LastSessionDate
        {
            get
            {
                return lastSessionDate;
            }
            set
            {
                lastSessionDate = value;
                RaisePropertyChanged();
            }
        }


        //Constructor
        public EmployeeOverviewViewModel(INavigationService navigationService, IDataService dataService)
        {
            this.navigationService = navigationService;
            this.dataService = dataService;

            LoadCommands();

            Messenger.Default.Register<User>(this, OnUserReceived);
        }

        //Methode om de ingelogde user in de property te laden
        private void OnUserReceived(User user)
        {
            LoggedInUser = user;
        }

        //Methode om de commands in te laden
        private void LoadCommands()
        {
            LogOutCommand = new CustomCommand(LogOut, CanLogOut);
            SearchCommand = new CustomCommand(Search, CanSearch);
            ClearSearchCommand = new CustomCommand(ClearSearch, CanClearSearch);
            LoadCommand = new CustomCommand(Load, CanLoad);
            SelectionChangedCommand = new CustomCommand(SelectionChanged, CanSelectionChangedExecute);
            NavigateToRegisterPageCommand = new CustomCommand(NavigateToRegisterPage, CanNavigateToRegisterPage);
            
        }

        //Implementatie van het log out command
        private void LogOut(object obj)
        {
            AverageTime = 0;
            MinimumTime = 0;
            MaximumTime = 0;
            TotalLength = 0;
            navigationService.NavigateTo("main");
        }

        private bool CanLogOut(object obj)
        {
            return true;
        }

        //Implementatie van het search command
        private void Search(object obj)
        {
            omittedUsers = Employees;
            Employees = Employees.Where(e => e.FullName.Contains(SearchString)).ToList();
        }

        private bool CanSearch(object obj)
        {
            if (SearchString != null && SearchString != "" && omittedUsers.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Implmentatie van het Clear search command
        private void ClearSearch(object obj)
        {
            Employees = omittedUsers;
            omittedUsers = new List<User>();
            SearchString = "";
        }

        private bool CanClearSearch(object obj)
        {
            if (omittedUsers.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        //Implentatie voor het load command dat uitgevoerd moet worden bij het laden van het scherm
        private async void Load(object obj)
        {
            try
            {
                Employees = dataService.GetAllUsersByRole("user");
            }
            catch (Exception)
            {
                var dialog = new MessageDialog("Error when trying to get the employees.");
                dialog.Title = ("Error");
                await dialog.ShowAsync();
            }
        }

        private bool CanLoad(object obj)
        {
            return true;
        }

        //Implementatie van het selection changed command dat uitgevoerd word als er een user geselecteerd word
        private async void SelectionChanged(object obj)
        {
            try
            {
                AverageTime = dataService.GetAverageTimeForUserId(SelectedEmployee.UserId);
                MinimumTime = dataService.GetMinimalTimeForUserId(SelectedEmployee.UserId);
                MaximumTime = dataService.GetMaximumTimeForUserId(SelectedEmployee.UserId);
                TotalLength = dataService.GetTotalLengthForUserId(SelectedEmployee.UserId);
            }
            catch (Exception)
            {
                var dialog = new MessageDialog("Error when trying to get the user data.");
                dialog.Title = ("Error");
                await dialog.ShowAsync();
            }

            //Als een user geen sessies heeft dan vervangen we de datum met een nieuwe datetime die door de converter in een boodschap word omgezet
            try
            {
                Session session = dataService.GetLastSession(SelectedEmployee.UserId);
                LastSessionDate = session.End_Time;
            }
            catch (Exception)
            {
                LastSessionDate = new DateTime();
            }

        }

        private bool CanSelectionChangedExecute(object obj)
        {
            //Controle anders ontstaat er bij het zoeken op naam een exception 
            if (SelectedEmployee != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        //Implementatie van navigate to register page command
        private void NavigateToRegisterPage(object obj)
        {
            AverageTime = 0;
            MinimumTime = 0;
            MaximumTime = 0;
            TotalLength = 0;
            navigationService.NavigateTo("register");
        }

        private bool CanNavigateToRegisterPage(object obj)
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
