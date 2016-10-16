using UWPMonitoring.App.Utility;
using UWPMonitoring.App.ViewModels;
using UWPMonitoring.DAL;

namespace UWPMonitoring.App
{
    public class ViewModelLocator
    {
        //Variabelen
        private static INavigationService navigationService = new NavigationService();
        private static IRepository repository = new Repository();

        private static MainViewViewModel mainViewViewModel = new MainViewViewModel(repository, navigationService);

        public static MainViewViewModel MainViewViewModel
        {
            get
            {
                return mainViewViewModel;
            }
        }
    }
}
