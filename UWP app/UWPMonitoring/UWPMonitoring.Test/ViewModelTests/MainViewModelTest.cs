using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMonitoring.App.Service;
using UWPMonitoring.App.Utility;
using UWPMonitoring.App.ViewModels;
using UWPMonitoring.DAL;
using UWPMonitoring.Domain;
using UWPMonitoring.Test.Mocks;
using Windows.UI.Xaml.Controls;
using Xunit;

namespace UWPMonitoring.Test.ViewModelTests
{
    public class MainViewModelTest
    {
        private MainViewViewModel mainViewViewModel;
        private IDataService dataService;
        private IRepository repository;
        private INavigationService navigationService;
        private User user;
        private Button button;

        public void init()
        {
            repository = new RepositoryMock();
            dataService = new DataService(repository);
            navigationService = new NavigationServiceMock();
            mainViewViewModel = new MainViewViewModel(navigationService, dataService);
            mainViewViewModel.User.UserId = 1309;
            mainViewViewModel.User.Password = "koen";
        }

        [Fact]
        public void LoginTest()
        {
            //Arrange
            init();

            //Act
            mainViewViewModel.LoginCommand.Execute("test");

            //Assert
            Assert.Equal(navigationService.Key, "Overview");
        }
    }
}
