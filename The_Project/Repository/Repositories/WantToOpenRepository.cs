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
    public class WantToOpenRepository : IRepository<WantToOpen>
    {
        private readonly IContext context;
        public WantToOpenRepository(IContext context)
        {
            this.context = context;
        }

        public async Task<WantToOpen> AddItem(WantToOpen item)
        {
            await context.WantToOpens.AddAsync(item);
            
            await context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            context.WantToOpens.Remove(await GetById(id));
            await context.Save();
        }

        public async Task<List<WantToOpen>> GetAll()
        {
            return await context.WantToOpens.ToListAsync();
        }

        public async Task<WantToOpen> GetById(int id)
        {
            return await context.WantToOpens.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WantToOpen> UpDateItem(int id, WantToOpen item)
        {
            var WantToOpen = await GetById(id);
            WantToOpen.Name = item.Name;
            WantToOpen.Category = item.Category;

            await context.Save();
            return WantToOpen;
        }
    }
}
