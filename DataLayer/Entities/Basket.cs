using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Basket : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public List<BasketItem>? CartLines { get; set; }
        [Precision(10, 2)]
        public decimal? Total { get; set; }

        public int? BillingAddressId { get; set; }
        [ForeignKey(nameof(BillingAddressId))]
        public Address? BillingAddress { get; set; }
        public int? ShippingAddressId { get; set; }
        [ForeignKey(nameof(ShippingAddressId))]
        public Address? ShippingAddress { get; set; }
        public int? PaymentProviderId { get; set; }
        public PaymentProvider? PaymentProvider { get; set; }
        public string state { get; set; } = "draft";
    }
}
