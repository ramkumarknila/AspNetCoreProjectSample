using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.App.Model;
using Web.App.BusinessLogic.BusinessLogic;
using Microsoft.AspNetCore.Authorization;

namespace Web.App.ApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        // GET api/registration/GetAllRegistrations
        [Authorize]
        [HttpGet("GetAllRegistrations")]
        public async Task<ICollection<RegistrationModel>> GetAllRegistrations()
        {
            using (var businessLogic = new RegistrationBusinessLogic())
            {
                return await businessLogic.GetAllRegistration();
            }
        }

      
        // GET api/registration/GetRegistrationById/1
       
        [HttpGet("GetRegistrationById/{registrationId}")]
        public async Task<RegistrationModel> GetRegistrationById(int registrationId)
        {
            using (var businessLogic = new RegistrationBusinessLogic())
            {
                return await businessLogic.GetRegistrationById(registrationId);
            }
        }

        // POST api/registration/AddRegistrationDetails
        [HttpPost("AddRegistrationDetails")]
        public async Task<int> AddRegistrationDetails(RegistrationModel registrationModel)
        {
            using (var businessLogic = new RegistrationBusinessLogic())
            {
                return await businessLogic.InsertRegistration(registrationModel);
            }
        }

        // PUT api/registration/EditRegistrationDetails
        [HttpPut("EditRegistrationDetails")]
        public async Task<int> EditRegistrationDetails(RegistrationModel registrationModel)
        {
            using (var businessLogic = new RegistrationBusinessLogic())
            {
                return await businessLogic.UpdateRegistration(registrationModel);
            }
        }
    }
}