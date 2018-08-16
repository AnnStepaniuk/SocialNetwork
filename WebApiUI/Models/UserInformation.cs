using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiUI.Models
{
    public class UserInformation
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

    }
}