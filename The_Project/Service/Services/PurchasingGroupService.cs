using AutoMapper;
using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities;
using Repository.Intefaces;
using Service.Interface;
using Microsoft.AspNetCore.Http;

namespace Service.Services
{
    public class PurchasingGroupService : IService<PurchasingGroupDto>
    {
        private readonly IRepository<PurchasingGroup> repository;
        //imapper-ממשק המטפל בהמרה
        private IMapper mapper;
        public PurchasingGroupService(IRepository<PurchasingGroup> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<PurchasingGroupDto> AddItem(PurchasingGroupDto item)
        {
            if (item.ImageFile != null)
            {
                var path = Path.Combine(Environment.CurrentDirectory + "/images/" + item.ImageFile.FileName);
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    item.ImageFile.CopyTo(fs);
                }
                //return mapper.Map<PlantDto>(await repository.AddItem(mapper.Map<Plant>(item)));
            }
            return mapper.Map<PurchasingGroupDto>(await repository.AddItem(mapper.Map<PurchasingGroup>(item)));
        }
        //public async Task<PurchasingGroupDto> AddItem(PurchasingGroupDto item)
        //{
        //    var path = Path.Combine(Environment.CurrentDirectory, "Images/", item.ImageFile.FileName);
        //    using (FileStream fs = new FileStream(path, FileMode.Create))
        //    {
        //        item.ImageFile.CopyTo(fs);
        //        //  fs.Close();
        //    }
        //    return mapper.Map<PurchasingGroupDto>(await repository.AddItem(mapper.Map<PurchasingGroup>(item)));
        //}

        public async Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<PurchasingGroupDto>> GetAll()
        {
            return mapper.Map<List<PurchasingGroupDto>>(await repository.GetAll());
        }
       
        public async Task<PurchasingGroupDto> GetById(int id)
        {

            return mapper.Map<PurchasingGroupDto>(await repository.GetById(id));

        }
        public async Task<PurchasingGroupDto> UpDateItem(int id, PurchasingGroupDto item)
        {
            return mapper.Map<PurchasingGroupDto>(await repository.UpDateItem(id, mapper.Map<PurchasingGroup>(item)));
        }
    }
}
