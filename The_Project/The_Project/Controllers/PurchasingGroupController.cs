using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace The_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasingGroupController : ControllerBase
    {
        private readonly IService<PurchasingGroupDto> service;
        public PurchasingGroupController(IService<PurchasingGroupDto> service)
        {
            this.service = service;
        }
        // GET: api/<PurchasingGroupController>
        [HttpGet]
        public Task<List<PurchasingGroupDto>> Get()
        {
            return service.GetAll();
        }

        // GET api/<PurchasingGroupController>/5
        [HttpGet("{id}")]
        public Task<PurchasingGroupDto> Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<PurchasingGroupController>
        [HttpPost]
        public async Task<PurchasingGroupDto> Post([FromForm] PurchasingGroupDto value)
        {
            return await service.AddItem(value);
        }

        // PUT api/<PurchasingGroupController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PurchasingGroupDto value)
        {
            await service.UpDateItem(id, value);
        }

        // DELETE api/<PurchasingGroupController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteItem(id);
        }
    }
}
