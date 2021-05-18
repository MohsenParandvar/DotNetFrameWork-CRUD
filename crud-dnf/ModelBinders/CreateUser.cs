using crud_dnf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crud_dnf.ModelBinders
{
    public class CreateUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailPass { get; set; }
    }
}