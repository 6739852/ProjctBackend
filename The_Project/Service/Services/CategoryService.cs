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
    public class CategoryService : IService<Category>
    {
        private readonly IRepository<Category> repository;
        public CategoryService(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task<Category> AddItem(Category item)
        {
           return await repository.AddItem(item);
        }

        public async Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<Category>> GetAll()
        {
           return await repository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await repository.GetById(id);
        }

        public async Task<Category> UpDateItem(int id, Category item)
        {
           return await repository.UpDateItem(id, item);  
        }
    }
}
