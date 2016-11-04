using HeadphoneDataApp.Model;
using HeadphoneDataApp.Tests.Mocks;
using HeadphoneDataApp.ViewModel;
using NUnit.Framework;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;

namespace HeadphoneDataApp.Tests
{
    [TestFixture]
    public class DeviceServiceViewModelTests
    {
        [Test]
        public void Correct_Uuid_On_GetServicesCommand()
        {
            DeviceServiceViewModel vm = new DeviceServiceViewModel();
            vm.Adapter = new AdapterMock();
            vm.Device = new DeviceMock();
            User u = new User();
            u.UserId = 15;
            vm.User = u;
            vm.AccelerometerService = new ServiceMock();

            vm.GetServicesCommand.Execute(null);

            Assert.AreEqual("f000aa81-0451-4000-b000-000000000000", vm.CharacteristicData.Uuid);
            Assert.AreEqual("f000aa82-0451-4000-b000-000000000000", vm.CharacteristicConfig.Uuid);
            Assert.AreEqual("f000aa83-0451-4000-b000-000000000000", vm.CharacteristicPeriod.Uuid);
        }
        [Test]
        public void Update_Label_When_Service_Found()
        {
            DeviceServiceViewModel vm = new DeviceServiceViewModel();
            vm.Adapter = new AdapterMock();
            vm.Device = new DeviceMock();
            vm.AccelerometerService = new ServiceMock();

            vm.findService();

            Assert.AreEqual(vm.Ready, "Found Accelerometer Service, feel free to press the button");
        }

        [Test]
        public void Label_Default_State_Test()
        {
            DeviceServiceViewModel vm = new DeviceServiceViewModel();
            Assert.AreEqual(vm.Ready, "please wait until the correct service has been found.");
        }
        [Test]
        public void Label_When_Service_Not_Found()
        {
            DeviceServiceViewModel vm = new DeviceServiceViewModel();
            vm.Adapter = new AdapterMock();
            DeviceMock dvm = new DeviceMock();
            dvm.ServicesIncorrect = new List<IService>();
            vm.Device = new DeviceMock();

            vm.AccelerometerService = new ServiceMock();

            vm.ScanForServices();

            Assert.AreEqual(vm.Ready, "No services, attempting to connect to device");
        }



    }

}