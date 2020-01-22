using System.ComponentModel.DataAnnotations;

namespace Web.App.Model.Administration
{
    public class RoleModel
    {
        [Required(ErrorMessage = "Role name is required")]
        public string RoleName { get; set; }

        //[Required(ErrorMessage = "Role name is required")]
        //public string Display { get; set; }
        //public string Description { get; set; }
    }
}
