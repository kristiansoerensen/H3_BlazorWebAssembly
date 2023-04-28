using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Required]
        public int? ProductId { get; set; }
        public Product? Product { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Filename { get; set; } = null!;
        [NotMapped]
        public IFormFile File { get; set; } = null!;
        public ICollection<Category>? Categories { get; set; }
    }
}
