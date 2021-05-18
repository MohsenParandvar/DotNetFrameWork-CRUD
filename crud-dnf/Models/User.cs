using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crud_dnf.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailPass { get; set; }

    }
}