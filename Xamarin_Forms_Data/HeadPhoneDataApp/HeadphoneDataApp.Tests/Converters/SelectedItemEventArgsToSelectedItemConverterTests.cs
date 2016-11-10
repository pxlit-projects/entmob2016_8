using System;
using NUnit.Framework;
using HeadphoneDataApp.Converters;
using Robotics.Mobile.Core.Bluetooth.LE;
using Xamarin.Forms;

namespace HeadphoneDataApp.Tests.Converters
{
    [TestFixture]
    class SelectedItemEventArgsToSelectedItemConverterTests
    {
        [Test]
        public void Convert_Returns_Correct_Object_Test()
        {
            SelectedItemEventArgsToSelectedItemConverter c = new SelectedItemEventArgsToSelectedItemConverter();
            TextCell selectedItem = new TextCell();
            selectedItem.Text = "selectedItem";
            SelectedItemChangedEventArgs args = new SelectedItemChangedEventArgs(selectedItem);
            object obj = c.Convert(args, null, null, null);
            TextCell extractedItem = (TextCell)obj;
            Assert.AreEqual(extractedItem, selectedItem);
        }
    }
}
