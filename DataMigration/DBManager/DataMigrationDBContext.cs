using DataMigration.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataMigration.DBManager
{
    public class DataMigrationDBContext : DbContext
    {
        public DataMigrationDBContext(DbContextOptions<DataMigrationDBContext> options) : base(options)
        {

        }

        public DbSet<EmployeeSqlModel> Employees { get; set; }
    }
}
