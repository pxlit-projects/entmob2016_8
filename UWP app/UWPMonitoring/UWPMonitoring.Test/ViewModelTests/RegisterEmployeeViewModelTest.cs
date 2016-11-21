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
using Xunit;

namespace UWPMonitoring.Test.ViewModelTests
{
    public class RegisterEmployeeViewModelTest
    {
        private IRepository repository;
        private IDataService dataService;
        private INavigationService navigationService;
        private RegisterEmployeeViewModel registerEmployeeViewModel;

        public void init()
        {
            repository = new RepositoryMock();
            dataService = new DataService(repository);
            navigationService = new NavigationServiceMock();
            registerEmployeeViewModel = new RegisterEmployeeViewModel(dataService, navigationService);
        }

        //Test om te controleren of de commandos goed worden ingeladen
        [Fact]
        public void LoadCommandsTest()
        {
            //Arrange + act
            init();

            //Assert
            Assert.NotNull(registerEmployeeViewModel.BackCommand);
            Assert.NotNull(registerEmployeeViewModel.RegisterCommand);
        }

        //Test van het register command
        [Fact]
        public void RegisterCommandTest()
        {
            //Arrange
            init();
            registerEmployeeViewModel.IsTesting = true; //Toegevoegd zodat bij het testen er geen dialog word weergegeven, dit gaf een exception
            registerEmployeeViewModel.NewUser.FirstName = "test";
            registerEmployeeViewModel.NewUser.LastName = "test";
            registerEmployeeViewModel.NewUser.Department = "test";

            //Act
            registerEmployeeViewModel.RegisterCommand.Execute("test");

            //Assert
            Assert.NotNull(registerEmployeeViewModel.NewUser.Password);
            Assert.NotNull(registerEmployeeViewModel.NewUser.Salt);
            Assert.Equal(128, registerEmployeeViewModel.NewUser.Password.Count());
            Assert.Equal(30, registerEmployeeViewModel.NewUser.Salt.Count());
            Assert.NotEqual(0, registerEmployeeViewModel.NewUser.UserId);
        }

        //Test van CanExecute van het register command
        [Fact]
        public void RegisterCommandCanExecuteTest()
        {
            //Arrange 1
            init();
            registerEmployeeViewModel.NewUser.FirstName = "test";

            //Act 1
            bool testNr1 = registerEmployeeViewModel.RegisterCommand.CanExecute("test"); //Moet false zijn

            //Arrange 2
            init();
            registerEmployeeViewModel.NewUser.LastName = "test";

            //Act 2
            bool testNr2 = registerEmployeeViewModel.RegisterCommand.CanExecute("test"); //Moet false zijn

            //Arrange 3
            init();
            registerEmployeeViewModel.NewUser.Department = "test";

            //Act 3
            bool testNr3 = registerEmployeeViewModel.RegisterCommand.CanExecute("test"); //Moet false zijn

            //Arrange 4
            init();

            //Act 4
            bool testNr4 = registerEmployeeViewModel.RegisterCommand.CanExecute("test"); //Moet false zijn

            //Arrange 5
            init();
            registerEmployeeViewModel.NewUser.FirstName = "";

            //Act 5
            bool testNr5 = registerEmployeeViewModel.RegisterCommand.CanExecute("test"); //Moet false zijn

            //Arrange 6
            init();
            registerEmployeeViewModel.NewUser.LastName = "";

            //Act 6
            bool testNr6 = registerEmployeeViewModel.RegisterCommand.CanExecute("test"); //Moet false zijn

            //Arrange 7
            init();
            registerEmployeeViewModel.NewUser.Department = "";

            //Act 7
            bool testNr7 = registerEmployeeViewModel.RegisterCommand.CanExecute("test"); //Moet false zijn

            //Arrange 8
            init();
            registerEmployeeViewModel.NewUser.FirstName = "test";
            registerEmployeeViewModel.NewUser.LastName = "test";
            registerEmployeeViewModel.NewUser.Department = "test";

            //Act 8
            bool testNr8 = registerEmployeeViewModel.RegisterCommand.CanExecute("test"); //Moet true zijn

            //Assert
            Assert.False(testNr1);
            Assert.False(testNr2);
            Assert.False(testNr3);
            Assert.False(testNr4);
            Assert.False(testNr5);
            Assert.False(testNr6);
            Assert.False(testNr7);
            Assert.True(testNr8);
        }

        [Fact]
        public void BackCommandTest()
        {
            //Arrange
            init();
            registerEmployeeViewModel.NewUser.FirstName = "test";
            registerEmployeeViewModel.NewUser.LastName = "test";
            registerEmployeeViewModel.NewUser.Department = "test";

            //Act
            registerEmployeeViewModel.BackCommand.Execute("test");

            //Assert
            Assert.Null(registerEmployeeViewModel.NewUser.FirstName);
            Assert.Null(registerEmployeeViewModel.NewUser.LastName);
            Assert.Null(registerEmployeeViewModel.NewUser.Department);
            Assert.Equal("Overview", navigationService.Key);
        }
    }
}
