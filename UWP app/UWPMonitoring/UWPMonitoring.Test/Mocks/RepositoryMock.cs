using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMonitoring.DAL;
using UWPMonitoring.Domain;

namespace UWPMonitoring.Test.Mocks
{
    public class RepositoryMock : IRepository
    {
        //Lijsten met mock data
        private List<User> userList;
        private List<Session> sessionListKoen;
        private List<Session> sessionListBrecht;
        private List<Session> sessionListJasper;
        private List<Session> sessionListStephane;

        public RepositoryMock()
        {
            LoadData();
        }

        //methode om de lijsten te vullen met mock data
        private void LoadData()
        {
            sessionListKoen = new List<Session>
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

            sessionListBrecht = new List<Session>
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

            sessionListJasper = new List<Session>
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

            sessionListStephane = new List<Session>
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

            userList = new List<User>
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

        public bool CheckIfUserIsValid(int userId, string password)
        {
            throw new NotImplementedException();
        }

        public List<Session> GetAllSessions()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Session GetSession(int sessionId)
        {
            throw new NotImplementedException();
        }

        public Session GetSessionByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserBySessionId(int sessionId)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsersByRole(string role)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfUserIsValid(int userId)
        {
            throw new NotImplementedException();
        }

        public double GetAverageTimeForuserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
