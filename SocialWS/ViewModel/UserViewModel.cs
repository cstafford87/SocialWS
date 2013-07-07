using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialWS.ViewModel
{
    public class UserViewModel
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid UserId { get; set; }
    }
}