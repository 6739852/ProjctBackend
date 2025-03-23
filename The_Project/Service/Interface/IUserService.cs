using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService<User>: IService<User>
    {  
        Task<User> GetByPasswordAndEmail(string idNumber, string Email);
        string Generate(User user);
    }
}
