using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robotics.Mobile.Core.Bluetooth.LE;

namespace HeadphoneDataApp.Tests.Mocks
{
    class AdapterMock : IAdapter
    {
        public IList<IDevice> ConnectedDevices
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<IDevice> DiscoveredDevices
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsScanning
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler<DeviceConnectionEventArgs> DeviceConnected;
        public event EventHandler<DeviceConnectionEventArgs> DeviceDisconnected;
        public event EventHandler<DeviceDiscoveredEventArgs> DeviceDiscovered;
        public event EventHandler ScanTimeoutElapsed;

        public void ConnectToDevice(IDevice device)
        {
            throw new NotImplementedException();
        }

        public void DisconnectDevice(IDevice device)
        {
            throw new NotImplementedException();
        }

        public void StartScanningForDevices()
        {
            throw new NotImplementedException();
        }

        public void StartScanningForDevices(Guid serviceUuid)
        {
            throw new NotImplementedException();
        }

        public void StopScanningForDevices()
        {
            throw new NotImplementedException();
        }
    }
}
