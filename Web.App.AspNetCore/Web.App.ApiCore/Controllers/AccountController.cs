using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web.App.Model;

namespace Web.App.ApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("CreateAccount")]
        public async Task<IEnumerable<string>> CreateAccount(UserAccount userAccountModel)
        {
            try
            {
                var user = new AppUser
                {
                    FirstName = userAccountModel.FirstName,
                    LastName = userAccountModel.LastName,
                    FacebookId = userAccountModel.FacebookId,
                    PictureUrl = userAccountModel.PictureUrl,
                    UserName = userAccountModel.UserName,
                    Email = userAccountModel.Email
                };
                var result = await userManager.CreateAsync(user, userAccountModel.Password);

                if (result.Succeeded)
                {
                    return new string[] { "Account created successfully..!" };
                }
                else
                {
                    var error = result.Errors.FirstOrDefault();
                    return new string[] { error.Description };
                }
            }
            catch(Exception ex)
            {
                return new string[] { ex.Message.FirstOrDefault().ToString() };
            }
           
        }

        [HttpPost("Login")]
        public async Task<object> Login(Login loginModel)
        {

            //var user = new AppUser
            //{
            //    Email = loginModel.EmailId
            //};
            //var result = await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
            var result = await signInManager.PasswordSignInAsync(loginModel.EmailId, loginModel.Password, false, false);

            if (result.Succeeded)
            {

                var appUser = userManager.Users.SingleOrDefault(r => r.UserName == loginModel.EmailId);
                return await GenerateJwtToken(loginModel.EmailId, appUser);
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }

        #region Private Functions
        /// <summary>
        /// Generate Authentication Token
        /// </summary>
        /// <param name="email"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<object> GenerateJwtToken(string email, AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtExpireMinutes"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}
