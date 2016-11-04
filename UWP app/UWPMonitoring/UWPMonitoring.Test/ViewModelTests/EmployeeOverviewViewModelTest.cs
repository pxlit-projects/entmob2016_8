using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMonitoring.App.Service;
using UWPMonitoring.App.Utility;
using UWPMonitoring.App.ViewModels;
using UWPMonitoring.DAL;
using UWPMonitoring.Test.Mocks;
using Xunit;

namespace UWPMonitoring.Test.ViewModelTests
{
    public class EmployeeOverviewViewModelTest
    {
        private IRepository repository;
        private IDataService dataService;
        private INavigationService navigationService;
        private EmployeeOverviewViewModel employeeOverviewViewmodel;

        public void init()
        {
            repository = new RepositoryMock();
            dataService = new DataService(repository);
            navigationService = new NavigationServiceMock();
            employeeOverviewViewmodel = new EmployeeOverviewViewModel(navigationService, dataService);
        }

        //Testen of alle commands goed worden ingeladen
        [Fact]
        public void LoadCommandsTest()
        {
            //Arrange + test
            init();

            //Assert
            Assert.NotNull(employeeOverviewViewmodel.ClearSearchCommand);
            Assert.NotNull(employeeOverviewViewmodel.LoadCommand);
            Assert.NotNull(employeeOverviewViewmodel.LogOutCommand);
            Assert.NotNull(employeeOverviewViewmodel.NavigateToRegisterPageCommand);
            Assert.NotNull(employeeOverviewViewmodel.SearchCommand);
            Assert.NotNull(employeeOverviewViewmodel.SelectionChangedCommand);
        }

        //Test van het logout command
        [Fact]
        public void LogOutTest()
        {
            //Arrange
            init();

            //Act
            employeeOverviewViewmodel.LogOutCommand.Execute("test");

            //Assert
            Assert.Equal("main", navigationService.Key);
        }

        //Test van het search command
        [Fact]
        public void SearchTest()
        {
            //Arrange
            init();
            employeeOverviewViewmodel.Employees = dataService.GetAllUsersByRole("user");
            employeeOverviewViewmodel.SearchString = "Jasper";


            //Act
            employeeOverviewViewmodel.SearchCommand.Execute("test");

            //Assert
            Assert.Equal(1, employeeOverviewViewmodel.Employees.Count());
            Assert.Contains("Jasper", employeeOverviewViewmodel.Employees.First().FullName);
        }

        //Test van het clear search command
        [Fact]
        public void ClearSearchTest()
        {
            //Arrange
            init();
            employeeOverviewViewmodel.Employees = dataService.GetAllUsersByRole("user");
            employeeOverviewViewmodel.SearchString = "Jasper";


            //Act
            employeeOverviewViewmodel.SearchCommand.Execute("test");
            employeeOverviewViewmodel.ClearSearchCommand.Execute("test");

            //Assert
            Assert.Equal("", employeeOverviewViewmodel.SearchString);
        }

        //Test van het load command
        [Fact]
        public void LoadTest()
        {
            //Arrange
            init();

            //Act
            employeeOverviewViewmodel.LoadCommand.Execute("test");

            //Assert
            Assert.NotEmpty(employeeOverviewViewmodel.Employees);
            Assert.Equal(3, employeeOverviewViewmodel.Employees.Count);
        }

        //Test van het selection changed command
        [Fact]
        public void SelectionChangedTest()
        {
            //Arrange
            init();
            employeeOverviewViewmodel.SelectedEmployee = repository.GetUserById(5678);

            //Act
            employeeOverviewViewmodel.SelectionChangedCommand.Execute("test");

            //Assert
            Assert.NotEqual(0, employeeOverviewViewmodel.AverageTime);
            Assert.NotEqual(0, employeeOverviewViewmodel.MinimumTime);
            Assert.NotEqual(0, employeeOverviewViewmodel.MaximumTime);
            Assert.NotEqual(0, employeeOverviewViewmodel.TotalLength);
            Assert.NotNull(employeeOverviewViewmodel.LastSessionDate);
        }

        //Test van het selection changed command als er een user word geselecteerd met geen sessions
        [Fact]
        public void SelectionChangedNoSessionsTest()
        {
            //Arrange
            init();
            employeeOverviewViewmodel.SelectedEmployee = repository.GetUserById(1);

            //Act
            employeeOverviewViewmodel.SelectionChangedCommand.Execute("test");

            //Assert
            Assert.Equal(0, employeeOverviewViewmodel.AverageTime);
            Assert.Equal(0, employeeOverviewViewmodel.MinimumTime);
            Assert.Equal(0, employeeOverviewViewmodel.MaximumTime);
            Assert.Equal(0, employeeOverviewViewmodel.TotalLength);
            Assert.Equal(new DateTime(), employeeOverviewViewmodel.LastSessionDate);
        }

        //Test voor het navigate to register page command
        [Fact]
        public void NavigateToRegisterPageTest()
        {
            //Arrange
            init();

            //Act
            employeeOverviewViewmodel.NavigateToRegisterPageCommand.Execute("test");

            //Act
            Assert.Equal(0, employeeOverviewViewmodel.AverageTime);
            Assert.Equal(0, employeeOverviewViewmodel.MinimumTime);
            Assert.Equal(0, employeeOverviewViewmodel.MaximumTime);
            Assert.Equal(0, employeeOverviewViewmodel.TotalLength);
            Assert.Equal("register", navigationService.Key);

        }
    }
}
