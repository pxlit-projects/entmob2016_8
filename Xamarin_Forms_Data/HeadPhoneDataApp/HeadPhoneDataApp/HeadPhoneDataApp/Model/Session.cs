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
        //[JsonProperty(PropertyName = "sessionId")]
        public int SessionId { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "startTime")]
        public long Start_Time { get; set; }

        [JsonProperty(PropertyName = "endTime")]
        public long End_Time { get; set; }

        [JsonProperty(PropertyName = "actualTime")]
        public int Actual_Time { get; set; }
    }
}
