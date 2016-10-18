using UWPMonitoring.App.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPMonitoring.App.Utility
{
    public class NavigationService : INavigationService
    {
        public void NavigateTo(string key)
        {
            if (key == "Overview")
            {
                EmployeeOverviewView view = new EmployeeOverviewView();
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(EmployeeOverviewView));
            }
        }
    }
}
