using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphoneApp.Model
{
    public class Characteristic
    {
        public Characteristic()
        {
            Descriptors = new List<Descriptor>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool CanRead { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanWrite { get; set; }

        public Object NativeCharacteristic { get; set; }

        public ICollection<Descriptor> Descriptors { get; set; }

        public Service Service { get; set; }
    }
}

