using System.Collections.Generic;
using UWPMonitoring.Domain;

namespace UWPMonitoring.DAL
{
    public interface IRepository
    {
        User GetUserById(int userId);
        User GetUserBySessionId(int sessionId);
        List<User> GetAllUsers();
        bool CheckIfUserIsValid(int userId);

        Session GetSession(int sessionId);
        Session GetSessionByUserId(int userId);
        List<Session> GetAllSessions();
    }
}
