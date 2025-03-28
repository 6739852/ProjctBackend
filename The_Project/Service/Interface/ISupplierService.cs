using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Repository.Entities;

namespace Service.Interface
{
    public interface ISupplierService<Supplier> : IService<Supplier>
    {
        Task<Supplier> GetByPasswordAndEmail(string idNumber, string Email);
        string Generate(Supplier supplier);
        Task<List<PurchasingGroupDto>> GetPurchasingGroupsById(int id);
        Task<List<WantToOpen>> GetWantToOpenById(int id);

    }
}
