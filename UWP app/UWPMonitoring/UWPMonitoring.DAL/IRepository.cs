using System.Collections.Generic;
using UWPMonitoring.Domain;

namespace UWPMonitoring.DAL
{
    public interface IRepository
    {
        User GetUser(int userId);
        User GetUserBySessionId(int sessionId);
        List<User> GetAllUsers();

        Session GetSession(int sessionId);
        Session GetSessionByUserId(int userId);
        List<Session> GetAllSessions();
    }
}
