using DataLayer.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ExtensionMethods
{
    public static class CategoryExtensions
    {
        //used by LINQ to SQL
        public static IEnumerable<CategoryDTO> ToDTOs(this IQueryable<Category> source)
        {
            List<Category> items = source.ToList();
            List<CategoryDTO> DTOs = new List<CategoryDTO>();
            foreach (Category item in items)
            {
                DTOs.Add(new CategoryDTO
                {
                    Id = item.Id,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    ProductIds = item.ProductCategories?.Select(pc => pc.ProductId).ToList(),
                    Description = item.Description,
                    Name = item.Name,
                });
            }
            return DTOs;
        }

        //used by LINQ to Linq
        public static IEnumerable<CategoryDTO> ToDTOs(this IEnumerable<Category> source)
        {
            List<CategoryDTO> DTOs = new List<CategoryDTO>();
            foreach (Category item in source)
            {
                DTOs.Add(new CategoryDTO
                {
                    Id = item.Id,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    ProductIds = item.ProductCategories?.Select(pc => pc.ProductId).ToList(),
                    Description = item.Description,
                    Name = item.Name,
                });
            }
            return DTOs;
        }

        public static Category FromDTO(this CategoryDTO source)
        {
            Category item = new Category
            {
                Id = source.Id,
                CreateDate = source.CreateDate,
                ModifiedDate = source.ModifiedDate,
                Description = source.Description,
                Name = source.Name,
            };

            return item;
        }
    }
}
