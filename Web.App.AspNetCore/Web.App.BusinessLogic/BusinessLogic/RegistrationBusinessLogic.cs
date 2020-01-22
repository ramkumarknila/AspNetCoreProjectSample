using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.App.BusinessLogic.Repositories;
using Web.App.BusinessLogic.Repositories.Interfaces;
using Web.App.Model;

namespace Web.App.BusinessLogic.BusinessLogic
{
    public class RegistrationBusinessLogic : IDisposable
    {
        private readonly IRegister _repository;
        private bool _disposed;

        public RegistrationBusinessLogic()
        {
            _repository = new RegistrationRepository();
        }

        public async Task<ICollection<RegistrationModel>> GetAllRegistration()
        {
            if (_disposed) throw new ObjectDisposedException(nameof(_repository));
            return _repository.GetAllRegistration() ?? new List<RegistrationModel>();
        }

        public async Task<RegistrationModel> GetRegistrationById(int? studentId)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(_repository));
            return studentId.HasValue ? _repository.GetRegistrationById((int)studentId) : new RegistrationModel();
        }

        public async Task<int> InsertRegistration(RegistrationModel model)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(_repository));
            return _repository.InsertRegistration(model);
        }

        public async Task<int> UpdateRegistration(RegistrationModel model)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(_repository));
            return _repository.UpdateRegistration(model);
        }

        public void Dispose()
        {
            if (_disposed) return;
            (_repository as IDisposable)?.Dispose();
            _disposed = true;
        }
    }
}
