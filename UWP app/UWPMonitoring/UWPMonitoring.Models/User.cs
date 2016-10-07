using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPMonitoring.Models
{
    public class User
    {
        public User()
        {
            Sessions = new List<Session>();
        }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Department { get; set; }

        public List<Session> Sessions { get; set; }
    }
}
