using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities;
using Common.Dto;


namespace Service.Interface
{
    public interface IUserService<User>: IService<User>
    {  
        Task<User> GetByPasswordAndEmail(string idNumber, string Email);
        string Generate(User user);
        Task<List<PurchasingGroupDto>> GetPurchasingGroupsById(int id);
        Task<List<WantToOpen>> GetWantToOpenById(int id);


    }
}
