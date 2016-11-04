using HeadphoneDataApp.Model;
using HeadphoneDataApp.Tests.Mocks;
using HeadphoneDataApp.ViewModel;
using NUnit.Framework;
using System;

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
    }
}