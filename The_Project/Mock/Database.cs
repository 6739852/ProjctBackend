using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Intefaces;

namespace Mock
{
    public class Database : DbContext, IContext
    {
        public DbSet<User> Users { get ; set ; }
        public DbSet<Supplier> Suppliers { get ; set ; }
        public DbSet<PurchasingGroup> PurchasingGroups { get ; set ; }
        public DbSet<WantToOpen> WantToOpens { get; set ; }
        public DbSet<Category> Categories { get ; set ; }

        public Task Save()
        {
           return SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-F7LCUQP; database=ProjectDb;trusted_connection=true;TrustServerCertificate=True");
        }
    }
}
