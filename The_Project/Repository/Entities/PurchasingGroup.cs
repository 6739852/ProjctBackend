using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Repository.Entities
{
    public class PurchasingGroup
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string ?ImageUrl { get; set; }
        //קשר לקטגוריה
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category ?Category { get; set; }
        public double Price { get; set; }
        //קשר לספק
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier ?Supplier { get; set; }
        public bool Status { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public int AmountMin { get; set; }
        public int CurrentAmount { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> ?Users { get; set; }
    }
}
