using DataMigration.DBManager;
using DataMigration.DBManagerService;
using DataMigration.DTO;
using DataMigration.Models;
using DataMigration.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataMigration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Employees : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<Employees> _logger;
        private readonly DataMigrationDBContext _dataMigrationDBContext;
        private readonly IEmployeeService _employeeService;

        public Employees(ILogger<Employees> logger, DataMigrationDBContext dataMigrationDBContext, IEmployeeService employeeService)
        {
            _logger = logger;
            _dataMigrationDBContext = dataMigrationDBContext;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeService.GetAll();
        }
        [HttpPost]
        public void Post()
        {
            var employees = _dataMigrationDBContext.Employees.Select(e => new Employee()
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Salary = e.Salary,
                Designation = e.Designation
            });

            _employeeService.InsertMany(employees);
        }
    }
}
