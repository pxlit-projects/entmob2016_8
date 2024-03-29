﻿using System.Collections.Generic;
using System.ComponentModel;

namespace EntityFramework.Domain
{

    public class User
    {
        //Constructor
        public User()
        {
            Sessions = new List<Session>();
            Credentials = new List<Credentials>();
        }

        //Properties
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Password { get; set; }

        public string Department { get; set; }

        public string Salt { get; set; }

        public string Role { get; set; }

        public List<Session> Sessions { get; set; }

        public List<Credentials> Credentials { get; set; }
    }
}
