using UWPMonitoring.App.Utility;
using Xunit;

namespace UWPMonitoring.Test.UtilityTests
{
    public class HasherTest
    {
        [Fact]
        public void ConvertStringToHashTest()
        {
            //Arrange
            string password = "test";
            string salt = "test";
            string result;
            string correctResult = "125d6d03b32c84d492747f79cf0bf6e179d287f341384eb5d6d3197525ad6be8e6df0116032935698f99a09e265073d1d6c32c274591bf1d0a20ad67cba921bc";

            //Act
            result = Hasher.ConvertStringToHash(password, salt);

            //Assert
            Assert.Equal(correctResult, result);
        }
    }
}
