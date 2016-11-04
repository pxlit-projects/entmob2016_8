﻿using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphoneDataApp.Tests.Mocks
{
    class DeviceMock : IDevice
    {
        Guid IDevice.ID
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IDevice.Name
        {
            get
            {
                return "CC2650 SensorTag";
            }
        }

        object IDevice.NativeDevice
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        int IDevice.Rssi
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IList<IService> IDevice.Services
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        DeviceState IDevice.State
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler IDevice.ServicesDiscovered
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

        void IDevice.DiscoverServices()
        {
            throw new NotImplementedException();
        }
    }
}
