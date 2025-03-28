using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Intefaces;

namespace Repository.Repositories
{
    public class SupplierRepository : IGetPurchasigGroups<Supplier>
    {
        private readonly IContext context;
        public SupplierRepository(IContext context)
        {
            this.context = context;
        }

        public async Task<Supplier> AddItem(Supplier item)
        {
            await context.Suppliers.AddAsync(item);
            await context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            context.Suppliers.Remove(await GetById(id));
            await context.Save();   
        }

        public async Task<List<Supplier>> GetAll()
        {
            return await context.Suppliers.ToListAsync();
        }

        //public async Task<PurchasingGroup> GetPurchasingGroupsById(int id)
        //{
        //}

        //public Task<List<PurchasingGroup>> IGetPurchasigGroups<Supplier>.GetPurchasingGroupsById(int id)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<List<PurchasingGroup>> GetPurchasingGroupsById(int id)
        {
            return await context.PurchasingGroups
             .Where(x => x.SupplierId == id)
             .ToListAsync();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await context.Suppliers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Supplier> UpDateItem(int id, Supplier item)
        {
            var supplier =await GetById(id);
            supplier.Name=item.Name;
            supplier.Phone = item.Phone;
            supplier.Email = item.Email;
            supplier.Authorized = item.Authorized;
            supplier.Rating = item.Rating;
            supplier.Categories = item.Categories;
            await context.Save();
            return item;
        }

        public async Task<List<WantToOpen>> GetWantToOpenById(int id)
        {
            return await context.WantToOpens
                 .Where(x => x.Id == x.Id)
                 .ToListAsync();
        }
    }
}
