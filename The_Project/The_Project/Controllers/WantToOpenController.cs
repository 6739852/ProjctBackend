using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace The_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WantToOpenController : ControllerBase
    {
        private readonly IService<WantToOpen> service;
        public WantToOpenController(IService<WantToOpen> service)
        {
            this.service = service;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public Task<List<WantToOpen>> Get()
        {
            return service.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Task<WantToOpen> Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        //[Authorize]//שור לאבטחה
        public async Task<WantToOpen> Post([FromBody] WantToOpen value)
        {
            return await service.AddItem(value);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] WantToOpen value)
        {
            await service.UpDateItem(id, value);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteItem(id);
        }

    }
}
