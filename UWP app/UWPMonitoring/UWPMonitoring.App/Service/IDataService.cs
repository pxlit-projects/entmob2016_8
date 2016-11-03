using UWPMonitoring.Domain;

namespace UWPMonitoring.App.Service
{
    public interface IDataService
    {
        Session GetLastSession(int userId);
    }
}
