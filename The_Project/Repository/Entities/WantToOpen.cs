using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class WantToOpen
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public int ?SupplierId { get; set; }
        //[ForeignKey("SupplierId")]
        //public virtual Supplier? Supplier { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public DateTime ApprovalDate { get; set; }
    }
}
