using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CRUD_AngularJs_ASPNET_MVC.Models
{
    public class BookDbContext : DbContext
    {
        static BookDbContext()
        {
            Database.SetInitializer<BookDbContext>(null);
        }
        public BookDbContext()
            : base("BookDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Book> Book { get; set; }
    }
}
