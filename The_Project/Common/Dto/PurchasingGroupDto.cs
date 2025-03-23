using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class PurchasingGroupDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int SupplierId { get; set; }
        public bool Status { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public int AmountMin { get; set; }
        public int CurrentAmount { get; set; }
        public string Description { get; set; }
        public byte[]? Image { get; set; }
        public IFormFile? ImageFile { get; set; }

    }
}
