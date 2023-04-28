using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [MaxLength(50, ErrorMessage = "Name can max be lenght of 50")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Precision(10, 2)]
        public decimal? Price { get; set; }
        public string? SKU { get; set; }
        [DisplayName("Category")]
        public ICollection<ProductCategory>? ProductCategories { get; set; }
        [DefaultValue(true)]
        public bool active { get; set; } = true;
        [DisplayName("Brand")]
        public int? BrandId { get; set; }
        [DisplayName("Brand")]
        [ForeignKey(nameof(BrandId))]
        public Brand? Brand { get; set; }
        public ICollection<Image>? Images { get; set; }
        public bool Featured { get; set; }
    }
}
