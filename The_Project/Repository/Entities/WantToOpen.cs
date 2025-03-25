using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class WantToOpen: PurchasingGroup
    {
        public int UserId { get; set; }
        public DateTime ApprovalDate { get; set; }
    }
}
