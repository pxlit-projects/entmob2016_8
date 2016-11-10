using Newtonsoft.Json;
using System;

namespace UWPMonitoring.Domain
{
    public class SessionWithLongs
    {
        [JsonProperty(PropertyName = "sessionId")]
        public int SessionId { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "startTime")]
        public long Start_Time { get; set; }

        [JsonProperty(PropertyName = "endTime")]
        public long End_Time { get; set; }

        [JsonProperty(PropertyName = "actualTime")]
        public int Actual_Time { get; set; }

        //Bron voor het omzetten van timestamp naar datetime: http://stackoverflow.com/questions/249760/how-to-convert-a-unix-timestamp-to-datetime-and-vice-versa
        public Session ToNormalSession()
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            DateTime startTime = dtDateTime.AddSeconds(this.Start_Time).ToLocalTime();
            DateTime endTime = dtDateTime.AddSeconds(this.End_Time).ToLocalTime();

            Session session = new Session();
            session.SessionId = this.SessionId;
            session.UserId = this.UserId;
            session.Start_Time = startTime;
            session.End_Time = endTime;
            session.Actual_Time = this.Actual_Time;

            return session;
        }
    }
}
