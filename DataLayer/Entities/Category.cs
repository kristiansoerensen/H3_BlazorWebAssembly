using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }
        public int? ImageId { get; set; }
        public Image? Image { get; set; }
    }
}
