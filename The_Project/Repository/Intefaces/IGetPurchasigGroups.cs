using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities;

namespace Repository.Intefaces
{
    public interface IGetPurchasigGroups<T>:IRepository<T>
    {
        Task<List<PurchasingGroup>> GetPurchasingGroupsById(int id);
        Task<List<WantToOpen>> GetWantToOpenById(int id);

    }
}
