using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphoneDataApp.Tests.Mocks
{
    class DeviceMock : IDevice
    {
        public Guid ID
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                return "MockDevice";
            }
        }

        public object NativeDevice
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Rssi
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<IService> Services
        {
            get
            {
                IList <IService> services = new List<IService>();
                services.Add(new ServiceMock());
                return services;
            }
        }

        public DeviceState State
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler ServicesDiscovered;

        public void DiscoverServices()
        {
            throw new NotImplementedException();
        }
    }
}
