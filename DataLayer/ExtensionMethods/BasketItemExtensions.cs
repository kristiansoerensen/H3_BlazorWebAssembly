using DataLayer.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ExtensionMethods
{
    public static class BasketItemExtensions
    {
        //used by LINQ to SQL
        public static IEnumerable<BasketItemDTO> ToDTOs(this IQueryable<BasketItem> source)
        {
            List<BasketItem> items = source.ToList();
            List<BasketItemDTO> DTOs = new List<BasketItemDTO>();
            foreach (BasketItem item in items)
            {
                DTOs.Add(new BasketItemDTO
                {
                    Id = item.Id,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    ProductId = item.ProductId,
                    BasketId = item.BasketId,
                    QTY = item.QTY,
                    Total = item.Total
                });
            }
            return DTOs;
        }

        //used by LINQ to Linq
        public static IEnumerable<BasketItemDTO> ToDTOs(this IEnumerable<BasketItem> source)
        {
            List<BasketItemDTO> DTOs = new List<BasketItemDTO>();
            foreach (BasketItem item in source)
            {
                DTOs.Add(new BasketItemDTO
                {
                    Id = item.Id,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    ProductId = item.ProductId,
                    BasketId = item.BasketId,
                    QTY = item.QTY,
                    Total = item.Total
                });
            }
            return DTOs;
        }

        public static BasketItem FromDTO(this BasketItemDTO source)
        {
            BasketItem item = new BasketItem
            {
                Id = source.Id,
                CreateDate = source.CreateDate,
                ModifiedDate = source.ModifiedDate,
                ProductId = source.ProductId,
                BasketId = source.BasketId,
                QTY = source.QTY,
                Total = source.Total
            };

            return item;
        }
    }
}
