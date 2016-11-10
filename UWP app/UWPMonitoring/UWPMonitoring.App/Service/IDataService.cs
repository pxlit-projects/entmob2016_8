using System.Collections.Generic;
using UWPMonitoring.Domain;

namespace UWPMonitoring.App.Service
{
    public interface IDataService
    {
        //Properties
        string Message { get; set; }
        User RetrievedUser { get; }

        //Methodes
        bool Login(User user);
        Session GetLastSession(int userId);
        List<User> GetAllUsersByRole(string role);
        int GetAverageTimeForUserId(int userId);
        int GetMinimalTimeForUserId(int userId);
        int GetMaximumTimeForUserId(int userId);
        int GetTotalLengthForUserId(int userId);
        int RegisterEmployee(User newUser);
    }
}
