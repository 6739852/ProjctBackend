using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities;
using Repository.Intefaces;
using Service.Interface;

namespace Service.Services
{
    public class WantToOpenService : IService<WantToOpen>
    {
        private readonly IRepository<WantToOpen> repository;
        public WantToOpenService(IRepository<WantToOpen> repository)
        {
            this.repository = repository;
        }
        public async Task<WantToOpen> AddItem(WantToOpen item)
        {
            return await repository.AddItem(item);
        }

        public async Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<WantToOpen>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<WantToOpen> GetById(int id)
        {
            return await repository.GetById(id);
        }

        public async Task<WantToOpen> UpDateItem(int id, WantToOpen item)
        {
            return await repository.UpDateItem(id, item);
        }
    }
}
