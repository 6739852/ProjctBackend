using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ISupplierService<Supplier> : IService<Supplier>
    {
        Task<Supplier> GetByPasswordAndEmail(string idNumber, string Email);
        string Generate(Supplier supplier);
    }
}
