using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository.Intefaces
{
    public interface IContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchasingGroup> PurchasingGroups { get; set; }
        public DbSet<WantToOpen> WantToOpens{ get; set; }
        public DbSet<Category> Categories { get; set; }

        public Task Save();

    }
}
