using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interface;
using The_Project.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace The_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService<Supplier> service;
        public SupplierController(ISupplierService<Supplier> service)
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
        //[HttpPost]
        //public async Task<Supplier> Post([FromBody] Supplier supplier)
        //{
        //    return await service.AddItem(supplier);
        //}

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Supplier value)
        {
            await service.UpDateItem(id, value);
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SupplierLogin supplierLogin)
        {
            if (supplierLogin == null || string.IsNullOrEmpty(supplierLogin.Password) || string.IsNullOrEmpty(supplierLogin.Email))
            {
                return BadRequest("Both Email and Password are required.");
            }

            var supplier = await service.GetByPasswordAndEmail(supplierLogin.Password, supplierLogin.Email);
            if (supplier == null)
            {
                return BadRequest("Supplier not found");
            }

            var token = service.Generate(supplier);
            Ok(new { Token = token });
            ReturnSupplier returnSupplier = new ReturnSupplier(token, supplier.Name, supplier.NumOfCurrentGroups);
            return Ok(returnSupplier);
        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> Post([FromBody] Supplier supplier)
        {
            await service.AddItem(supplier);
            var token = service.Generate(supplier);
            ReturnSupplier returnSupplier = new ReturnSupplier(token, supplier.Name, supplier.NumOfCurrentGroups);
            return Ok(returnSupplier);
        }
        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteItem(id);
        }
    }
}
