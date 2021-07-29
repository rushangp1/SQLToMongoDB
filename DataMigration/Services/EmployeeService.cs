using DataMigration.DBManagerService;
using DataMigration.DTO;
using DataMigration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataMigration.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMongoDBService _mongoDBService;

        public EmployeeService(IMongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _mongoDBService.GetAll<EmployeeModel>()
                .Select(e => new Employee()
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Designation = e.Designation,
                    Salary = e.Salary
                });
        }
        public void InsertMany(IEnumerable<Employee> employees)
        {
            _mongoDBService.InsertMany<EmployeeModel>(employees.Select(e => new EmployeeModel()
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Designation = e.Designation,
                Salary = e.Salary
            }));
        }
    }
}
