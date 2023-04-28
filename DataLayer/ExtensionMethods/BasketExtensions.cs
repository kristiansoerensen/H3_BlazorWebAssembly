using DataLayer.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ExtensionMethods
{
    public static class BasketExtensions
    {
        //used by LINQ to SQL
        public static IEnumerable<BasketDTO> ToDTOs(this IQueryable<Basket> source)
        {
            List<Basket> items = source.ToList();
            List<BasketDTO> DTOs = new List<BasketDTO>();
            foreach (Basket item in items)
            {
                DTOs.Add(new BasketDTO
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    Total = item.Total,
                    CartItemIds = item.CartLines?.Select(x => x.Id).ToList(),
                    BillingAddressId = item.BillingAddressId,
                    ShippingAddressId = item.ShippingAddressId,
                    PaymentProviderId = item.PaymentProviderId,
                    state = item.state
                });
            }
            return DTOs;
        }

        //used by LINQ to Linq
        public static IEnumerable<BasketDTO> ToDTOs(this IEnumerable<Basket> source)
        {
            List<BasketDTO> DTOs = new List<BasketDTO>();
            foreach (Basket item in source)
            {
                DTOs.Add(new BasketDTO
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    Total = item.Total,
                    CartItemIds = item.CartLines?.Select(x => x.Id).ToList(),
                    BillingAddressId = item.BillingAddressId,
                    ShippingAddressId = item.ShippingAddressId,
                    PaymentProviderId = item.PaymentProviderId,
                    state = item.state
                });
            }
            return DTOs;
        }

        public static Basket FromDTO(this BasketDTO source)
        {
            Basket item = new Basket
            {
                Id = source.Id,
                UserId = source.UserId,
                CreateDate = source.CreateDate,
                ModifiedDate = source.ModifiedDate,
                Total = source.Total,
                BillingAddressId = source.BillingAddressId,
                ShippingAddressId = source.ShippingAddressId,
                PaymentProviderId = source.PaymentProviderId,
                state = source.state
            };

            return item;
        }
    }
}
