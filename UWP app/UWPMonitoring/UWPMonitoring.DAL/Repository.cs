using System;
using System.Collections.Generic;
using UWPMonitoring.Models;

namespace UWPMonitoring.DAL
{
    public class Repository : IRepository
    {
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
