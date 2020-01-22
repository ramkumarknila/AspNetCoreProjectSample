using System;
using System.Collections.Generic;
using System.Linq;
using Web.App.BusinessLogic.Repositories.Interfaces;
using Web.App.DataAccess;
using Web.App.Model;

namespace Web.App.BusinessLogic.Repositories
{
    public class RegistrationRepository : IRegister, IDisposable
    {

        private readonly RegistrationDataAccess _registrationDataAccess;
        private bool _disposed;

        public RegistrationRepository()
        {
            _registrationDataAccess = new RegistrationDataAccess();
        }

        public ICollection<RegistrationModel> GetAllRegistration()
        {
            if (_disposed) throw new ObjectDisposedException(nameof(RegistrationRepository));

            List<RegistrationModel> _registrationList = (from r in _registrationDataAccess.GetAllRegistration() select new RegistrationModel
            {
                EmailId = r.EmailId,
                MobileNumber =r.MobileNumber,
                StudentId =r.StudentId,
                StudentName =r.StudentName
            }).ToList();

            return _registrationList ?? new List<RegistrationModel>();
        }

        public RegistrationModel GetRegistrationById(int studentId)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(RegistrationRepository));

            RegistrationModel _registrationModel = (from r in _registrationDataAccess.GetRegistrationById(studentId) select new RegistrationModel
            {
                EmailId = r.EmailId,
                MobileNumber = r.MobileNumber,
                StudentId = r.StudentId,
                StudentName = r.StudentName
            }).SingleOrDefault();

            return _registrationModel ?? new RegistrationModel();
        }

        public int InsertRegistration(RegistrationModel model)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(RegistrationRepository));
            int _registrationId = _registrationDataAccess.InsertRegistration(model);
            return _registrationId;
        }

        public int UpdateRegistration(RegistrationModel model)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(RegistrationRepository));
            int _registrationId = _registrationDataAccess.UpdateRegistration(model);
            return _registrationId;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _registrationDataAccess?.Dispose();
            _disposed = true;
        }
    }
}
