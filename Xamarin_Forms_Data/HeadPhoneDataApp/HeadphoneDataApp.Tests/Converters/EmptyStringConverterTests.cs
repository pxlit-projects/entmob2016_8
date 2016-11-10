using System;
using NUnit.Framework;
using HeadphoneDataApp.Converters;
using HeadphoneDataApp.Tests.Mocks;

namespace HeadphoneDataApp.Tests.Converters
{
    [TestFixture]
    public class EmptyStringConverterTests
    {
        [Test]
        public void Unnamed_Object_Converts_To_Default_String_Test()
        {
            EmptyStringConverter c = new EmptyStringConverter();
            DeviceMock d = new DeviceMock(); 
            //default name is null
            object s = c.Convert(d.getName, null, new object(), new System.Globalization.CultureInfo(1) );
            Assert.AreEqual("<un-named device>", s);
        }

        [Test]
        public void named_Object_Converts_To_Own_String_Test()
        {
            EmptyStringConverter c = new EmptyStringConverter();
            DeviceMock d = new DeviceMock();
            d.setName = "Bluetooth device 1";
            object s = c.Convert(d.getName, null, new object(), new System.Globalization.CultureInfo(1));
            Assert.AreEqual("Bluetooth device 1", s);
        }

    }
}
