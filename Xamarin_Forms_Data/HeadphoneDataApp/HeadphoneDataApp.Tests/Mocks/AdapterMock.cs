using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphoneDataApp.Tests.Mocks
{
    public class AdapterMock : IAdapter
    {
        private bool isScanning;
       
        public bool IsScanning
        {
            
            set { isScanning = value; }
        }

        IList<IDevice> IAdapter.ConnectedDevices
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IList<IDevice> IAdapter.DiscoveredDevices
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool IAdapter.IsScanning
        {
            get
            {
                // is scanning false;
                return isScanning;
            }
        }

        event EventHandler<DeviceConnectionEventArgs> IAdapter.DeviceConnected
        {
            add
            {
                
                //return new DeviceConnectionEventArgs();
                //throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<DeviceConnectionEventArgs> IAdapter.DeviceDisconnected
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<DeviceDiscoveredEventArgs> IAdapter.DeviceDiscovered
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler IAdapter.ScanTimeoutElapsed
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        void IAdapter.ConnectToDevice(IDevice device)
        {
            //throw new NotImplementedException();
        }

        void IAdapter.DisconnectDevice(IDevice device)
        {
            throw new NotImplementedException();
        }

        void IAdapter.StartScanningForDevices()
        {
            throw new NotImplementedException();
        }

        void IAdapter.StartScanningForDevices(Guid serviceUuid)
        {
            throw new NotImplementedException();
        }

        void IAdapter.StopScanningForDevices()
        {
            //stop scan
        }
    }
}
