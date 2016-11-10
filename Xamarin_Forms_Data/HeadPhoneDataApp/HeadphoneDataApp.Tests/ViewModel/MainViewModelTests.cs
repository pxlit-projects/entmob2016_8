using System;
using NUnit.Framework;
using HeadphoneDataApp.ViewModel;
using HeadphoneDataApp.Model;
using GalaSoft.MvvmLight.Messaging;
using Robotics.Mobile.Core.Bluetooth.LE;
using HeadphoneDataApp.Tests.Mocks;

namespace HeadphoneDataApp.Tests
{
    [TestFixture]
    public class MainViewModelTests
    {

        [Test]
        public void Found_Device()
        {
            MainViewModel main = new MainViewModel();
            var device = new DeviceMock();
            main.Devices.Add(device);
            Assert.That(main.Devices!=null);
        }

        [Test]
        public void Keep_list_If_scanning()
        {
            var a = new AdapterMock();
            a.IsScanning = true;// de IsScanning staat op true
            //Bij het starten van de scan en de adapter is  aan het scannen dan maakt hij de list devices NIET leeg
            MainViewModel main = new MainViewModel();
            main.Adapter = a;
            var device = new DeviceMock();
            main.Devices.Add(device);
            main.StartScanning();
            Assert.That(main.Devices!=null);
        }

        public void Clear_List_If_scanning()
        {
            var a = new AdapterMock();
            a.IsScanning = false;// de IsScanning staat op true
            //Bij het starten van de scan en de adapter is nog niet aan het scannen dan maakt hij de list devices leeg
            MainViewModel main = new MainViewModel();
            main.Adapter = a;
            var device = new DeviceMock();
            main.Devices.Add(device);
            main.StartScanning();
            Assert.That(main.Devices == null);
        }

    }
}
