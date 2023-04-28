using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Precision(10, 2)]
        public decimal? Price { get; set; }
        public string? SKU { get; set; }
        [DefaultValue(true)]
        public bool active { get; set; } = true;
        [DisplayName("Brand")]
        public int? BrandId { get; set; }
        public bool Featured { get; set; }
        public List<int>? CategoryIds { get; set; }
        public List<int>? ImageIds { get; set; }
    }
}
