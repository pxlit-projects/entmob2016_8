using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robotics.Mobile.Core.Bluetooth.LE;

namespace HeadphoneDataApp.Tests.Mocks
{
    class Characteristic81Mock : ICharacteristic
    {
        public bool CanRead
        {
            get
            {
                return true;
            }
        }

        public bool CanUpdate
        {
            get
            {
                return true;
            }
        }

        public bool CanWrite
        {
            get
            {
                return true;
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
                return ID;
            }
            set
            {
                ID = value;
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
                return "f000aa81-0451-4000-b000-000000000000";
            }
            set
            {
                Uuid = value;
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
