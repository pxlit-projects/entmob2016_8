using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphoneDataApp.Model
{
    public class Session
    {
        public int SessionId { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }

        public DateTime Start_Time { get; set; }

        public DateTime End_Time { get; set; }

        public int Actual_Time { get; set; }
    }
}
