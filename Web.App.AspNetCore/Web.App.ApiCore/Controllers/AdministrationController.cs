using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.App.Model;
using Web.App.Model.Administration;

namespace Web.App.ApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpPost("CreateRole")]
        public async Task<IEnumerable<string>> CreateRole(RoleModel roleModel)
        {
            IdentityRole identityRole = new IdentityRole
            {
                Name = roleModel.RoleName
            };

            IdentityResult result = await roleManager.CreateAsync(identityRole);

            if (result.Succeeded)
            {
                return new string[] { "Role created successfully..!" };
            }
            else
            {
                var error = result.Errors.FirstOrDefault();
                return new string[] { error.Description };
            }
        }
    }
}
