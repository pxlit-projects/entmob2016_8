using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMonitoring.App.Converters;
using Xunit;

namespace UWPMonitoring.Test.ConverterTests
{
    public class SecondConverterTest
    {
        private SecondConverter secondConverter;

        [Fact]
        public void ConvertTest()
        {
            //Arrange
            string tijd;
            int seconden = 3800;
            secondConverter = new SecondConverter();
            string expected = string.Format("{0} Uren, {1} Minuten en {2} Seconden", 1, 3, 20);

            //Act
            tijd = (string)secondConverter.Convert(seconden, typeof(string), null, "nl");

            //Assert
            Assert.Equal(expected, tijd);
        }
    }
}
