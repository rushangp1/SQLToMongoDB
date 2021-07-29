using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataMigration.DTO
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public string Designation { get; set; }
    }
}
