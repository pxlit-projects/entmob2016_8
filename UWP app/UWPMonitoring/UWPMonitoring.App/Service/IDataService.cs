using UWPMonitoring.Domain;

namespace UWPMonitoring.App.Service
{
    public interface IDataService
    {
        string Message { get; set; }
        User RetrievedUser { get; }

        bool Login(User user);
        Session GetLastSession(int userId);
    }
}
