using DataMigration.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataMigration.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        void InsertMany(IEnumerable<Employee> employees);
    }
}
