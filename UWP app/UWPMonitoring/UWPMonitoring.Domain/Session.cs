using System;
using Newtonsoft.Json;

namespace UWPMonitoring.Domain
{
    public class Session
    {
        [JsonProperty(PropertyName = "sessionId")]
        public int SessionId { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "startTime")]
        public DateTime Start_Time { get; set; }

        [JsonProperty(PropertyName = "endTime")]
        public DateTime End_Time { get; set; }

        [JsonProperty(PropertyName = "actualTime")]
        public int Actual_Time { get; set; }
    }
}
