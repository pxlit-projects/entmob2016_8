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
        private List<Session> sessionList;

        public RepositoryMock()
        {
            LoadData();
        }

        //methode om de lijsten te vullen met mock data
        private void LoadData()
        {
            userList = new List<User>
            {
                new User
                {
                    UserId = 1309,
                    FirstName = "Koen",
                    LastName = "Castermans",
                    Password = "KoenPass",
                    Department = "Verkoop",
                    Sessions = null
                },

                new User
                {
                    UserId = 1234,
                    FirstName = "Brecht",
                    LastName = "Morrhey",
                    Password = "BrechtPass",
                    Department = "Verkoop",
                    Sessions = null
                },

                 new User
                {
                    UserId = 4321,
                    FirstName = "Jasper",
                    LastName = "Szkudlarski",
                    Password = "BrechtPass",
                    Department = "Verkoop",
                    Sessions = null
                }
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
    }
}
