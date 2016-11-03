using UWPMonitoring.App.Service;
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
        private static IDataService dataService = new DataService(repository);

        private static MainViewViewModel mainViewViewModel = new MainViewViewModel(navigationService, dataService);
        private static EmployeeOverviewViewModel employeeOverviewViewModel = new EmployeeOverviewViewModel(navigationService, repository, dataService);
        private static RegisterEmployeeViewModel registerEmployeeViewModel = new RegisterEmployeeViewModel(repository, navigationService);

        //Properties
        public static MainViewViewModel MainViewViewModel
        {
            get
            {
                return mainViewViewModel;
            }
        }

        public static EmployeeOverviewViewModel EmployeeOverviewViewModel
        {
            get
            {
                return employeeOverviewViewModel;
            }
        }

        public static RegisterEmployeeViewModel RegisterEmployeeViewModel
        {
            get
            {
                return registerEmployeeViewModel;
            }
        }
    }
}
