using DataLayer.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ExtensionMethods
{
    public static class PaymentProviderExtensions
    {
        //used by LINQ to SQL
        public static IEnumerable<PaymentProviderDTO> ToDTOs(this IQueryable<PaymentProvider> source)
        {
            List<PaymentProvider> items = source.ToList();
            List<PaymentProviderDTO> DTOs = new List<PaymentProviderDTO>();
            foreach (PaymentProvider item in items)
            {
                DTOs.Add(new PaymentProviderDTO
                {
                    Id = item.Id,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    Name = item.Name,
                });
            }
            return DTOs;
        }

        //used by LINQ to Linq
        public static IEnumerable<PaymentProviderDTO> ToDTOs(this IEnumerable<PaymentProvider> source)
        {
            List<PaymentProviderDTO> DTOs = new List<PaymentProviderDTO>();
            foreach (PaymentProvider item in source)
            {
                DTOs.Add(new PaymentProviderDTO
                {
                    Id = item.Id,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    Name = item.Name,
                });
            }
            return DTOs;
        }

        public static PaymentProvider FromDTO(this PaymentProviderDTO source)
        {
            PaymentProvider item = new PaymentProvider
            {
                Id = source.Id,
                CreateDate = source.CreateDate,
                ModifiedDate = source.ModifiedDate,
                Name = source.Name,
            };

            return item;
        }
    }
}
