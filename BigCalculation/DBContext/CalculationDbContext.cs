using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BigCalculation.Models;

namespace BigCalculation.DBContext
{
    public class CalculationDbContext: DbContext
    {
        public CalculationDbContext()
            : base("DataConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CalculationHistory> CalculationHistories { get; set; }
    }
}