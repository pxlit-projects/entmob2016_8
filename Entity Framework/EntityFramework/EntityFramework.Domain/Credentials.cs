﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain
{
    public class Credentials
    {
        public int CredentialId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Service { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
