using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLine.Core.DAO;

namespace LifeLine.Infrastructure
{
    public class BloodDonorContext : DbContext
    {
        public BloodDonorContext()
            : base("name=BloodDonorContextConnectionString")
        {
            var a = Database.Connection.ConnectionString;
        }
        public DbSet<BloodDonor> BloodDonors { get; set; }
    }  
}
