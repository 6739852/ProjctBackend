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
    public class SupplierService : IService<Supplier>
    {   private readonly IRepository<Supplier> repository;
        public SupplierService(IRepository<Supplier> repository)
        {
            this.repository = repository;
        }
        public async Task<Supplier> AddItem(Supplier item)
        {
            return await repository.AddItem(item);
        }

        public async Task DeleteItem(int id)
        {
           await repository.DeleteItem(id);
        }

        public async Task<List<Supplier>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await repository.GetById(id);
        }

        public Task<Supplier> UpDateItem(int id, Supplier item)
        {
            throw new NotImplementedException();
        }
    }
}
