using System;
using NUnit.Framework;
using HeadphoneDataApp.ViewModel;
using Xamarin.Forms;
using HeadphoneDataApp.Repository;

namespace HeadphoneDataApp.Tests
{
    [TestFixture]
    public class LoginViewModelTests
    {
        [Test]
        public void Valid_Login_Test()
        {
            IRepository repo = new Mocks.RepositoryMock();
            LoginViewModel vm = new LoginViewModel();
            vm.Repository = repo;

            vm.Username = "7";
            vm.Password = "koen";

            vm.LoginCommand.Execute(null);

            Assert.AreEqual("", vm.ValidationErrors);
        }

        [Test]
        public void Invalid_Id_Login_Test()
        {
            IRepository repo = new Mocks.RepositoryMock();
            LoginViewModel vm = new LoginViewModel();
            vm.Repository = repo;

            vm.Username = "999999";
            vm.Password = "koen";

            vm.LoginCommand.Execute(null);

            Assert.AreEqual("UserId is Incorrect", vm.ValidationErrors);
            
        }

        [Test]
        public void Invalid_Password_Login_Test()
        {
            IRepository repo = new Mocks.RepositoryMock();
            LoginViewModel vm = new LoginViewModel();
            vm.Repository = repo;

            vm.Username = "7";
            vm.Password = "koed";

            vm.LoginCommand.Execute(null);

            Assert.AreEqual("Password is incorrect", vm.ValidationErrors);
        }

        [Test]
        public void Empty_Password_Login_Test()
        {
            IRepository repo = new Mocks.RepositoryMock();
            LoginViewModel vm = new LoginViewModel();
            vm.Repository = repo;

            vm.Username = "7";
            vm.Password = "";

            vm.LoginCommand.Execute(null);

            Assert.AreEqual("\nPlease enter a password.", vm.ValidationErrors);
        }

        [Test]
        public void Empty_Id_Login_Test()
        {
            IRepository repo = new Mocks.RepositoryMock();
            LoginViewModel vm = new LoginViewModel();
            vm.Repository = repo;

            vm.Username = "";
            vm.Password = "koen";

            vm.LoginCommand.Execute(null);

            Assert.AreEqual("Please enter a username.", vm.ValidationErrors);
        }

        [Test]
        public void Empty_Id_And_Password_Login_Test()
        {
            IRepository repo = new Mocks.RepositoryMock();
            LoginViewModel vm = new LoginViewModel();
            vm.Repository = repo;

            vm.Username = "";
            vm.Password = "";

            vm.LoginCommand.Execute(null);

            Assert.AreEqual("Please enter a username.\nPlease enter a password.", vm.ValidationErrors);
        }
    }
}
