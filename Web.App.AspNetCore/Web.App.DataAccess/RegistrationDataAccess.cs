using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Web.App.Data.DbContexts;
using Web.App.Data.Tables;
using Web.App.Model;

namespace Web.App.DataAccess
{
    public class RegistrationDataAccess : IDisposable
    {
        private readonly SchoolDbContext _context;
        private bool _disposed;
       
        public RegistrationDataAccess()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost; Database=School; Trusted_Connection=True; MultipleActiveResultSets=True;");
            _context = new SchoolDbContext(optionsBuilder.Options);
        }
        public IQueryable<Registration> GetAllRegistration()
        {
            if (_disposed) throw new ObjectDisposedException(nameof(SchoolDbContext));
            return (from r in _context.Registrations select r);
        }

        public IQueryable<Registration> GetRegistrationById(int StudentId)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(SchoolDbContext));
            return (from r in _context.Registrations where r.StudentId == StudentId select r);
        }

        public int InsertRegistration(RegistrationModel model)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(SchoolDbContext));

            Registration reg = new Registration();
            reg.StudentName = model.StudentName;
            reg.MobileNumber = model.MobileNumber;
            reg.EmailId = model.EmailId;
            _context.Registrations.Add(reg);
            _context.SaveChanges();

            return reg.StudentId;
        }

        public int UpdateRegistration(RegistrationModel model)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(SchoolDbContext));

            Registration reg = new Registration();
            reg = _context.Registrations.Find(model.StudentId);
            reg.StudentName = model.StudentName;
            reg.MobileNumber = model.MobileNumber;
            reg.EmailId = model.EmailId;
            _context.SaveChanges();

            return reg.StudentId;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _context?.Dispose();
            _disposed = true;
        }
    }
}
