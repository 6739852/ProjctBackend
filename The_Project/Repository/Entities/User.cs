using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Alerts { get; set; }
        public string Password { get; set; }
        public  virtual ICollection<PurchasingGroup> ?PurchasingGroups { get; set; }

    }
}
