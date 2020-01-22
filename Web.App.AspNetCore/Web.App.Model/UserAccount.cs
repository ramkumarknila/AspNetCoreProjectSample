using System;
using System.Collections.Generic;
using System.Text;

namespace Web.App.Model
{
    public class UserAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PictureUrl { get; set; }
        public long FacebookId { get; set; }
        public string Password { get; set; }
    }
}
