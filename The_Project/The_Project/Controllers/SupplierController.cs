using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace The_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IService<Supplier> service;
        public SupplierController(IService<Supplier> service)
        {
              this.service = service;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public Task<List<Supplier>> Get()
        {
            return service.GetAll();
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public Task<Supplier> Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public async Task<Supplier> Post([FromBody] Supplier value)
        {
            return await service.AddItem(value);
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Supplier value)
        {
            await service.UpDateItem(id, value);
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteItem(id);
        }
    }
}
