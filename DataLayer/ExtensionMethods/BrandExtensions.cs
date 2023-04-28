using DataLayer.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ExtensionMethods
{
    public static class BrandExtensions
    {
        //used by LINQ to SQL
        public static IEnumerable<BrandDTO> ToDTOs(this IQueryable<Brand> source)
        {
            List<Brand> items = source.ToList();
            List<BrandDTO> DTOs = new List<BrandDTO>();
            foreach (Brand item in items)
            {
                DTOs.Add(new BrandDTO
                {
                    Id = item.Id,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    ProductIds = item.Products?.Select(x => x.Id).ToList(),
                    Name = item.Name,
                });
            }
            return DTOs;
        }

        //used by LINQ to Linq
        public static IEnumerable<BrandDTO> ToDTOs(this IEnumerable<Brand> source)
        {
            List<BrandDTO> DTOs = new List<BrandDTO>();
            foreach (Brand item in source)
            {
                DTOs.Add(new BrandDTO
                {
                    Id = item.Id,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    ProductIds = item.Products?.Select(x => x.Id).ToList(),
                    Name = item.Name,
                });
            }
            return DTOs;
        }

        public static Brand FromDTO(this BrandDTO source)
        {
            Brand item = new Brand
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
