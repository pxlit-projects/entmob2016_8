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

        //Constructor
        public EmployeeOverviewViewModel(INavigationService navigationService, IRepository repository)
        {
            this.navigationService = navigationService;
            this.repository = repository;

            LoadCommands();
            LoadTestData();

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

        //methode voor testdata te laden
        public void LoadTestData()
        {
            List<Session> sessionListKoen = new List<Session>
            {
                new Session
                {
                    SessionId = 1,
                    UserId = 1309,
                    Start_Time = new DateTime(2016,10,18,13,0,0),
                    End_Time = new DateTime(2016,10,18,14,0,0),
                    Actual_Time = new DateTime(),
                },

                 new Session
                {
                    SessionId = 2,
                    UserId = 1309,
                    Start_Time = new DateTime(2016,10,18,14,0,0),
                    End_Time = new DateTime(2016,10,18,15,0,0),
                    Actual_Time = new DateTime(),
                },
            };

            List<Session> sessionListBrecht = new List<Session>
            {
                new Session
                {
                    SessionId = 3,
                    UserId = 1234,
                    Start_Time = new DateTime(2016,10,18,13,0,0),
                    End_Time = new DateTime(2016,10,18,14,0,0),
                    Actual_Time = new DateTime(),
                },

                 new Session
                {
                    SessionId = 4,
                    UserId = 1234,
                    Start_Time = new DateTime(2016,10,18,14,0,0),
                    End_Time = new DateTime(2016,10,18,15,0,0),
                    Actual_Time = new DateTime(),
                },
            };

            List<Session> sessionListJasper = new List<Session>
            {
                new Session
                {
                    SessionId = 5,
                    UserId = 4321,
                    Start_Time = new DateTime(2016,10,18,13,0,0),
                    End_Time = new DateTime(2016,10,18,14,0,0),
                    Actual_Time = new DateTime(),
                },

                 new Session
                {
                    SessionId = 6,
                    UserId = 4321,
                    Start_Time = new DateTime(2016,10,18,14,0,0),
                    End_Time = new DateTime(2016,10,18,15,0,0),
                    Actual_Time = new DateTime(),
                },
            };

            List<Session> sessionListStephane = new List<Session>
            {
                new Session
                {
                    SessionId = 7,
                    UserId = 5678,
                    Start_Time = new DateTime(2016,10,18,13,0,0),
                    End_Time = new DateTime(2016,10,18,14,0,0),
                    Actual_Time = new DateTime(),
                },

                 new Session
                {
                    SessionId = 8,
                    UserId = 5678,
                    Start_Time = new DateTime(2016,10,18,14,0,0),
                    End_Time = new DateTime(2016,10,18,15,0,0),
                    Actual_Time = new DateTime(),
                },
            };

            Employees = new List<User>
            {
                new User
                {
                    UserId = 1309,
                    FirstName = "Koen",
                    LastName = "Castermans",
                    Password = "KoenPass",
                    Department = "Verkoop",
                    Sessions = sessionListKoen
                },

                new User
                {
                    UserId = 1234,
                    FirstName = "Brecht",
                    LastName = "Morrhey",
                    Password = "BrechtPass",
                    Department = "Verkoop",
                    Sessions = sessionListBrecht
                },

                new User
                {
                    UserId = 4321,
                    FirstName = "Jasper",
                    LastName = "Szkudlarski",
                    Password = "JasperPass",
                    Department = "Verkoop",
                    Sessions = sessionListJasper
                },

                new User
                {
                    UserId = 5678,
                    FirstName = "Stephane",
                    LastName = "Oris",
                    Password = "StephanePass",
                    Department = "Verkoop",
                    Sessions = sessionListStephane
                },
            };
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
