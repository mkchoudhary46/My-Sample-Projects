using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLine.Core;
using LifeLine.Core.DAO;

namespace LifeLine.Infrastructure
{
    public class BloodDonorContext : DbContext, IBloodDonorContext
    {
        private bool IsDisposed { get; set; }

        public BloodDonorContext()
            : base("name=BloodDonorContextConnectionString")
        {
            var a = Database.Connection.ConnectionString;
        }
        static BloodDonorContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BloodDonorContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public static BloodDonorContext Create()
        {
            return new BloodDonorContext();
        }
        public IDbSet<BloodDonor> BloodDonors { get; set; }
    }
    public interface IBloodDonorContext
    {
        IDbSet<BloodDonor> BloodDonors { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
