using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPMonitoring.Models
{
    public class Session
    {
        public int SessionId { get; set; }

        public int UserId { get; set; }

        public DateTime Start_Time { get; set; }

        public DateTime End_Time { get; set; }

        public DateTime Actual_Time { get; set; }
    }
}
