using UWPMonitoring.App.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPMonitoring.App.Utility
{
    public class NavigationService : INavigationService
    {
        private string key;

        public string Key
        {
            get
            {
                return key;
            }
        }

        public void NavigateTo(string key)
        {
            this.key = key;
            if (key == "Overview")
            {
                
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(EmployeeOverviewView));
            }
            if (key == "main")
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(MainView));
            }
            if (key == "register")
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(RegisterEmployeeView));
            }
        }
    }
}
