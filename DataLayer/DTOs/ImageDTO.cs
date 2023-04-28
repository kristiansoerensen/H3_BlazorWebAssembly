using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Filename { get; set; } = null!;
        public List<int>? CategoryIds { get; set; }
    }
}
