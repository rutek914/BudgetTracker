using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Model.Entities
{
    public class BudgetTrackerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<BudgetTrackerDbContext>
    {
        public BudgetTrackerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BudgetTrackerDbContext>();
            var connectionString = ConfigurationManager.ConnectionStrings["BudgetTracker"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);

            return new BudgetTrackerDbContext(optionsBuilder.Options);
        }
    }
}
