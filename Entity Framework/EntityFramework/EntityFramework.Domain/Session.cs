using System;

namespace EntityFramework.Domain
{
    public class Session
    {
        public int SessionId { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public DateTime Start_Time { get; set; }

        public DateTime End_Time { get; set; }

        public int Actual_Time { get; set; }
    }
}
