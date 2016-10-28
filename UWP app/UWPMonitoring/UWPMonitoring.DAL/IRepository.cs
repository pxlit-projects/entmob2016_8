using System.Collections.Generic;
using UWPMonitoring.Domain;

namespace UWPMonitoring.DAL
{
    public interface IRepository
    {
        User GetUserById(int userId);
        List<User> GetAllUsersByRole(string role);
        bool CheckIfUserIsValid(int userId);

        double GetAverageTimeForuserId(int id);
    }
}
