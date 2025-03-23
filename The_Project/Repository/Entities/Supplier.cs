using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Authorized { get; set; }
        public int Rating { get; set; }
        //הגדרת קבוצות רכישה לכל סםק יש פה כנראה טעות לבדוק איך עושים את זה
        public virtual ICollection<PurchasingGroup>? PurchasingGroups { get; set; }
        public virtual ICollection<Category> ?Categories{ get; set; }
    }
}
