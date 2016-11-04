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

        public void init()
        {
            repository = new RepositoryMock();
            dataService = new DataService(repository);
            navigationService = new NavigationServiceMock();
            mainViewViewModel = new MainViewViewModel(navigationService, dataService);
        }

        //Testen of de commands goed geladen worden
        [Fact]
        public void LoadCommandsTest()
        {
            //Arrange + act
            init();

            //Assert
            Assert.NotNull(mainViewViewModel.LoginCommand);
        }

        //Test een goede login
        [Fact]
        public void GoodLoginTest()
        {
            //Arrange
            init();
            mainViewViewModel.User.UserId = 1309;
            mainViewViewModel.User.Password = "koen";

            //Act
            mainViewViewModel.LoginCommand.Execute("test");

            //Assert
            Assert.Equal("Overview",navigationService.Key);
        }

        //Test van een login met een onbestaand user ID
        [Fact]
        public void BadLoginWrongIdTest()
        {
            //Arrange
            init();
            mainViewViewModel.User.UserId = 999;
            mainViewViewModel.User.Password = "koen";

            //Act
            mainViewViewModel.LoginCommand.Execute("test");

            //Assert
            Assert.Equal("Het ingevulde id bestaat niet.", mainViewViewModel.Message);
        }

        //Test van een login met een verkeerd wachtwoord
        [Fact]
        public void BadLoginWrongPassTest()
        {
            //Arrange
            init();
            mainViewViewModel.User.UserId = 1309;
            mainViewViewModel.User.Password = "test";

            //Act
            mainViewViewModel.LoginCommand.Execute("test");

            //Assert
            Assert.Equal("Dit is geen geldig wachtwoord.", mainViewViewModel.Message);
        }

        //Test van een login van een user met de role user
        [Fact]
        public void BadLoginWrongRoleTest()
        {
            //Arrange
            init();
            mainViewViewModel.User.UserId = 1234;
            mainViewViewModel.User.Password = "brecht";

            //Act
            mainViewViewModel.LoginCommand.Execute("test");

            //Assert
            Assert.Equal("Deze gebruiker heeft geen admin rechten.", mainViewViewModel.Message);
        }
    }
}
