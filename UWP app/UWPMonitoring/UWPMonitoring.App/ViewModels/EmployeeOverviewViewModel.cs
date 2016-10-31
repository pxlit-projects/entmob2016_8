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
    public class EmployeeOverviewViewModel : INotifyPropertyChanged
    {
        //Variabbelen
        private INavigationService navigationService;
        private IRepository repository;
        private List<User> employees;
        private User selectedEmployee;
        private List<User> omittedUsers = new List<User>();
        private string searchString;
        private int averageTime;
        private int minimumTime;
        private int maximumTime;
        private int totalLength;

        //Commands
        public CustomCommand LogOutCommand { get; set; }
        public CustomCommand SearchCommand { get; set; }
        public CustomCommand ClearSearchCommand { get; set; }
        public CustomCommand LoadCommand { get; set; }
        public CustomCommand SelectionChangedCommand { get; set; }

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
            
        }

        //Implementatie van het log out command
        private void LogOut(object obj)
        {
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
        private void Load(object obj)
        {
            Employees = repository.GetAllUsersByRole("user");
        }

        private bool CanLoad(object obj)
        {
            return true;
        }

        //Implementatie van het selection changed command dat uitgevoerd word als er een user geselecteerd word
        private void SelectionChanged(object obj)
        {
            AverageTime = repository.GetAverageTimeForUserId(SelectedEmployee.UserId);
            MinimumTime = repository.GetMinimalTimeForUserId(SelectedEmployee.UserId);
            MaximumTime = repository.GetMaximumTimeForUserId(SelectedEmployee.UserId);
            TotalLength = repository.GetTotalLengthForUserId(SelectedEmployee.UserId);
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
