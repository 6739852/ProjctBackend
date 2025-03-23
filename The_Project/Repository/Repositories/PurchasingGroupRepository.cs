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
    public class PurchasingGroupRepository : IRepository<PurchasingGroup>
    {
        private readonly IContext context;
        public PurchasingGroupRepository(IContext context)
        {
            this.context = context;
        }

        public async Task<PurchasingGroup> AddItem(PurchasingGroup item)
        {
            await context.PurchasingGroups.AddAsync(item);
            await context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        { 
            context.PurchasingGroups.Remove(await GetById(id));
            await context.Save();
        }

        public async Task<List<PurchasingGroup>> GetAll()
        {
            return await context.PurchasingGroups.ToListAsync();
        }

        public async Task<PurchasingGroup> GetById(int id)
        {
            return await context.PurchasingGroups.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PurchasingGroup> UpDateItem(int id, PurchasingGroup item)
        {
            var purchasingGroup=await GetById(id);
            purchasingGroup.Name=item.Name;
            purchasingGroup.Category = item.Category;
            purchasingGroup.Price = item.Price;
            purchasingGroup.Supplier = item.Supplier;
            purchasingGroup.Status = item.Status;
            purchasingGroup.OpeningDate = item.OpeningDate;
            purchasingGroup.ClosedDate = item.ClosedDate;
            purchasingGroup.AmountMin = item.AmountMin;
            purchasingGroup.CurrentAmount = item.CurrentAmount;
            purchasingGroup.Description = item.Description;
            purchasingGroup.Users = item.Users;
            await context.Save();
            return purchasingGroup;
        }
    }
}
