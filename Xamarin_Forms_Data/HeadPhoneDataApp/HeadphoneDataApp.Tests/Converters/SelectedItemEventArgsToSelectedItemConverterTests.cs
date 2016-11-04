using System;
using NUnit.Framework;
using HeadphoneDataApp.Converters;
using Robotics.Mobile.Core.Bluetooth.LE;

namespace HeadphoneDataApp.Tests.Converters
{
    [TestFixture]
    class SelectedItemEventArgsToSelectedItemConverterTests
    {
        [Test]
        public void Convert_Returns_Correct_Object_Type_Test()
        {
            SelectedItemEventArgsToSelectedItemConverter c = new SelectedItemEventArgsToSelectedItemConverter();
            object obj = c.Convert(new CharacteristicReadEventArgs(), null, null, null);
            Assert.AreEqual(obj.GetType(), new CharacteristicReadEventArgs().GetType());
        }
    }
}
