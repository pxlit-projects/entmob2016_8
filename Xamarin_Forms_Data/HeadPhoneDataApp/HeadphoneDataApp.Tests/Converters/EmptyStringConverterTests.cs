using System;
using NUnit.Framework;
using HeadphoneDataApp.Converters;

namespace HeadphoneDataApp.Tests.Converters
{
    [TestFixture]
    public class EmptyStringConverterTests
    {
        [Test]
        public void Unnamed_Object_Converts_To_Default_String_Test()
        {
            EmptyStringConverter c = new EmptyStringConverter();
            object s = c.Convert(new object(), null, new object(), new System.Globalization.CultureInfo(1) );
            Assert.AreEqual("<un-named device>", s);
        }

        [Test]
        public void named_Object_Converts_To_Own_String_Test()
        {
            EmptyStringConverter c = new EmptyStringConverter();
            object obj = new object();
            object s = c.Convert(obj, null, new object(), new System.Globalization.CultureInfo(1));
            Assert.AreEqual("obj", s);
        }

    }
}
