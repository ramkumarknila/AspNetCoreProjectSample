using System;
using System.Collections.Generic;
using System.Text;
using Web.App.Model;

namespace Web.App.BusinessLogic.Repositories.Interfaces
{
    public interface IRegister
    {
        ICollection<RegistrationModel> GetAllRegistration();
        RegistrationModel GetRegistrationById(int studentId);
        int InsertRegistration(RegistrationModel model);
        int UpdateRegistration(RegistrationModel model);
    }
}
