using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<int>? ProductIds { get; set; }
        public int? ImageId { get; set; }
    }
}
