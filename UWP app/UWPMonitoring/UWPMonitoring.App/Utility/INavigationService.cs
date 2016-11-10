namespace UWPMonitoring.App.Utility
{
    public interface INavigationService
    {
        string Key { get; }

        void NavigateTo(string key);
    }
}
