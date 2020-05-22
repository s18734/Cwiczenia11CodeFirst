using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wyklad11.Models;

namespace Wyklad11.Services
{
    public class efDbService : IDBService
    {

        private readonly DoctorDbContext _dbService;
        public efDbService(DoctorDbContext dbContext)
        {
            _dbService = dbContext;
        }
        public bool AddDoctor(Doctor doc)
        {
            _dbService.Add(doc);
            try
            {
                _dbService.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }

        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _dbService.Doctor.ToList();
        }

        public bool RemoveDoctor(Doctor doc)
        {
            _dbService.Remove(doc);
            try
            {
                _dbService.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateDoctor(Doctor doc)
        {
            _dbService.Update(doc);
            try
            {
                _dbService.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
