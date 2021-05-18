using crud_dnf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crud_dnf.DTOs
{
    public class UserDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}