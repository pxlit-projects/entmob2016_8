using System.Linq;
using UWPMonitoring.App.Utility;
using Xunit;

namespace UWPMonitoring.Test.UtilityTests
{
    public class RandomPasswordTest
    {

        //Test voor de generate methode waarbij er geen parameters mee worden gegeven
        [Fact]
        public void GenerateNoParamTest()
        {
            //Arrange
            string password;

            //Act
            password = RandomPassword.Generate();

            //Assert
            Assert.True(password.Count() >= 8 && password.Count() <= 10);
        }

        //Test voor de generate methode waar de lengte mee word gegeven
        [Fact]
        public void GenerateWithLengthTest()
        {
            //Arrange
            string password;
            int length = 12;

            //Act
            password = RandomPassword.Generate(length);

            //Assert
            Assert.True(password.Count() == length);
        }

        //Test voor de generate methode waar de minimum lengte en maximum lengte word meegegeven
        [Fact]
        public void GenerateWithTwoLengthTest()
        {
            //Arrange
            string password;
            int minLength = 12;
            int maxLength = 16;

            //Act
            password = RandomPassword.Generate(minLength, maxLength);

            //Assert
            Assert.True(password.Count() >= minLength && password.Count() <= maxLength);
        }
    }
}
