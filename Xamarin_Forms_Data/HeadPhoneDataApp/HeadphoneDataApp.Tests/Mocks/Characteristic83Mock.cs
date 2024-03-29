﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robotics.Mobile.Core.Bluetooth.LE;

namespace HeadphoneDataApp.Tests.Mocks
{
    class Characteristic83Mock : ICharacteristic
    {
        public bool CanRead
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool CanUpdate
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool CanWrite
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<IDescriptor> Descriptors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

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
                throw new NotImplementedException();
            }
        }

        public object NativeCharacteristic
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public CharacteristicPropertyType Properties
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string StringValue
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Uuid
        {
            get
            {
                return "f000aa83-0451-4000-b000-000000000000";
            }
        }

        public byte[] Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler<CharacteristicReadEventArgs> ValueUpdated;

        public Task<ICharacteristic> ReadAsync()
        {
            throw new NotImplementedException();
        }

        public void StartUpdates()
        {
            throw new NotImplementedException();
        }

        public void StopUpdates()
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
