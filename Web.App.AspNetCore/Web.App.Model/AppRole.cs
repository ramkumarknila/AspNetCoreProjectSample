using Microsoft.AspNetCore.Identity;

namespace Web.App.Model
{
    public class AppRole : IdentityRole
    {
        public string Display { get; set; }
        public string Description { get; set; }
    }
}
