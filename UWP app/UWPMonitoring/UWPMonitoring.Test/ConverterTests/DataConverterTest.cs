using UWPMonitoring.App.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UWPMonitoring.Test.ConverterTests
{
    public class DataConverterTest
    {
        private DateConverter dateConverter;

        //Testen met een normale datum
        [Fact]
        public void ConvertNormalDateTest()
        {
            //Arrange
            DateTime date = new DateTime(1996,9,13);
            dateConverter = new DateConverter();
            string expected = "September 13, 1996";
            string actual;

            //Act
            actual = (string)dateConverter.Convert(date, typeof(string), null, "nl");

            //Assert
            Assert.Equal(expected, actual);
        }

        //Testen met de standaard datum die een bepaalde boodschap terug zou moeten geven
        [Fact]
        public void ConvertStandardDateTest()
        {
            //Arrange
            DateTime date = new DateTime();
            dateConverter = new DateConverter();
            string expected = "This user doesn't have any sessions yet.";
            string actual;

            //Act
            actual = (string)dateConverter.Convert(date, typeof(string), null, "nl");

            //Assert
            Assert.Equal(expected, actual);

        }
    }
}
