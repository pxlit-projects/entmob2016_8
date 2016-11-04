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
            sessionListBrecht = new List<Session>
            {
                new Session
                {
                    SessionId = 3,
                    UserId = 1234,
                    Start_Time = new DateTime(2016,10,18,13,0,0),
                    End_Time = new DateTime(2016,10,18,14,0,0),
                    Actual_Time = 2,
                },

                 new Session
                {
                    SessionId = 4,
                    UserId = 1234,
                    Start_Time = new DateTime(2016,10,18,14,0,0),
                    End_Time = new DateTime(2016,10,18,15,0,0),
                    Actual_Time = 2,
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
                    Actual_Time = 2,
                },

                 new Session
                {
                    SessionId = 6,
                    UserId = 4321,
                    Start_Time = new DateTime(2016,10,18,14,0,0),
                    End_Time = new DateTime(2016,10,18,15,0,0),
                    Actual_Time = 2,
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
                    Actual_Time = 2,
                },

                 new Session
                {
                    SessionId = 8,
                    UserId = 5678,
                    Start_Time = new DateTime(2016,10,18,14,0,0),
                    End_Time = new DateTime(2016,10,18,15,0,0),
                    Actual_Time = 2,
                },
            };

            userList = new List<User>
            {
                new User
                {
                    UserId = 1309,
                    FirstName = "Koen",
                    LastName = "Castermans",
                    Password = "c1e33790556faca15631bfa546cbb7182dfb6032a076f47ed158e7b64ccaccfbfa58261b15bf4000f3fb1714357f6e955467233c0082af260a61e3858b9f0935", // koen
                    Salt = "salt",
                    Department = "Verkoop",
                    Role = "admin",
                    Sessions = new List<Session>()
                },

                new User
                {
                    UserId = 1234,
                    FirstName = "Brecht",
                    LastName = "Morrhey",
                    Password = "e1919879f2c972002c220a9ebf64c3f90b6eaec52a072bba7e7e1918ef5eafaf72097e86b19458af159417059f3f00ee6035366ec90cdad300d9ead6e4b632b9", //brecht
                    Salt = "salt",
                    Department = "Verkoop",
                    Role = "user",
                    Sessions = sessionListBrecht
                },

                new User
                {
                    UserId = 4321,
                    FirstName = "Jasper",
                    LastName = "Szkudlarski",
                    Password = "12b1462ec31f8cd412f451ca7ad3a78b13e59973f52268b71ed29646405955444e81c7bef9e1d18c07d6b61a1fc3f87cd00dbc19c66e1c1c64697e863452871a", //jasper
                    Salt = "salt",
                    Department = "Verkoop",
                    Role = "user",
                    Sessions = sessionListJasper
                },

                new User
                {
                    UserId = 5678,
                    FirstName = "Stephane",
                    LastName = "Oris",
                    Password = "50b3edb7ce73fb7a0a48ff74c69be838e67c5fb2d8bfa2084d457e6cc5213849205a1476fc4dbd7d73070377dad7b99b885b63219518a3f8792679b2a49cba61", //stephane
                    Salt = "salt",
                    Department = "Verkoop",
                    Role = "user",
                    Sessions = sessionListStephane
                },
            };

            
        }

        public User GetUserById(int userId)
        {
            User user = userList.Where(u => u.UserId == userId).First();
            return user;
        }

        public List<User> GetAllUsersByRole(string role)
        {
            List<User> usersByRole = userList.Where(u => u.Role == role).ToList();
            return usersByRole;
        }

        public bool CheckIfUserIsValid(int userId)
        {
            try
            {
                User user = userList.Where(u => u.UserId == userId).Single();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public int RegisterEmployee(User newUser)
        {
            userList.Add(newUser);
            return newUser.UserId;
        }

        public int GetAverageTimeForUserId(int userId)
        {
            int sum = 0;
            User user = userList.Where(u => u.UserId == userId).First();
            foreach (Session s in user.Sessions)
            {
                sum += (int)s.End_Time.Subtract(s.Start_Time).TotalSeconds;
            }

            return sum / user.Sessions.Count();
        }

        public int GetMinimalTimeForUserId(int userId)
        {
            int min = int.MaxValue;
            int result;
            User user = userList.Where(u => u.UserId == userId).First();
            foreach (Session s in user.Sessions)
            {
                result = (int)s.End_Time.Subtract(s.Start_Time).TotalSeconds;
                if (result < min)
                {
                    min = result;
                }
            }

            return min;
        }

        public int GetMaximumTimeForUserId(int userId)
        {
            int max = int.MinValue;
            int result;
            User user = userList.Where(u => u.UserId == userId).First();
            foreach (Session s in user.Sessions)
            {
                result = (int)s.End_Time.Subtract(s.Start_Time).TotalSeconds;
                if (result > max)
                {
                    max = result;
                }
            }

            return max;
        }

        public int GetTotalLengthForUserId(int userId)
        {
            int sum = 0;
            User user = userList.Where(u => u.UserId == userId).First();
            foreach (Session s in user.Sessions)
            {
                sum += (int)s.End_Time.Subtract(s.Start_Time).TotalSeconds;
            }

            return sum;
        }

        public SessionWithLongs GetLastSession(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
