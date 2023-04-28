using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public string? Street { get; set; }
        public string? Street2 { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
    }
}
