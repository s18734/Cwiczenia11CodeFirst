using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wyklad11.Models;

namespace Wyklad11.Services
{
    public interface IDBService
    {
        public IEnumerable<Doctor> GetDoctors();
        public bool AddDoctor(Doctor doc);
        public bool RemoveDoctor(Doctor doc);
        public bool UpdateDoctor(Doctor doc);
    }
}
