using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class BasketDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? UserId { get; set; }
        public List<int>? CartItemIds { get; set; }
        public decimal? Total { get; set; }
        public int? BillingAddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public int? PaymentProviderId { get; set; }
        public string state { get; set; } = "draft";
    }
}
