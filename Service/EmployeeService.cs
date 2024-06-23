using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT.DAL.Interfaces;
using Domain.Entity;

namespace Service
{
    public class EmployeeService
    {
        private readonly iBaseRepository<Employee> _db;
        public EmployeeService(iBaseRepository<Employee> db)
        {
            _db = db;
        }

        public async Task<Employee> Test()
        {
            return (await _db.GetAll()).FirstOrDefault();
        }

    }
}
