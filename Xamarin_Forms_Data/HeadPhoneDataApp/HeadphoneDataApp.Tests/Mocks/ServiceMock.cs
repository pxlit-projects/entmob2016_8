using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphoneDataApp.Tests.Mocks
{
    class ServiceMock : IService
    {
        public IList<ICharacteristic> Characteristics
        {
            get
            {
                List<ICharacteristic> chars = new List<ICharacteristic>();
                ICharacteristic m1 = new Characteristic81Mock();
                ICharacteristic m2 = new Characteristic82Mock();
                ICharacteristic m3 = new Characteristic83Mock();

                chars.Add(m1);
                chars.Add(m2);
                chars.Add(m3);

                return chars;
            }
        }

        public Guid ID
        {
            get
            {
                return new Guid("f000aa80-0451-4000-b000-000000000000");
            }
        }

        public bool IsPrimary
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return "mock";
            }
        }

        public event EventHandler CharacteristicsDiscovered;

        public void DiscoverCharacteristics()
        {
            throw new NotImplementedException();
        }

        public ICharacteristic FindCharacteristic(KnownCharacteristic characteristic)
        {
            return new Characteristic81Mock();
        }
    }
}
