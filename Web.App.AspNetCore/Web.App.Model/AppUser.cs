﻿using Microsoft.AspNetCore.Identity;

namespace Web.App.Model
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? FacebookId { get; set; }
        public string PictureUrl { get; set; }
    }
}
