using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DTOs;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.ExtensionMethods
{
    public static class ProductExtensions
    {
        //used by LINQ to SQL
        public static IEnumerable<ProductDTO> ToDTOs(this IQueryable<Product> source)
        {
            List<Product> products = source.ToList();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            foreach (Product item in products)
            {
                productDTOs.Add(new ProductDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    Description = item.Description,
                    BrandId = item.BrandId,
                    Price = item.Price,
                    active = item.active,
                    Featured = item.Featured,
                    SKU = item.SKU,
                    CategoryIds = item.ProductCategories?.Select(pc => pc.CategoryId).ToList(),
                    ImageIds = item.Images?.Select(i => i.Id).ToList()
                });
            }
            return productDTOs;
        }
        
        //used by LINQ to Linq
        public static IEnumerable<ProductDTO> ToDTOs(this IEnumerable<Product> source)
        {
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            foreach (Product item in source)
            {
                productDTOs.Add(new ProductDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    Description = item.Description,
                    BrandId = item.BrandId,
                    Price = item.Price,
                    active = item.active,
                    Featured = item.Featured,
                    SKU = item.SKU,
                    CategoryIds = item.ProductCategories?.Select(pc => pc.CategoryId).ToList(),
                    ImageIds = item.Images?.Select(i => i.Id).ToList()
                });
            }
            return productDTOs;
        }

        public static Product FromDTO(this ProductDTO source)
        {
            Product product = new Product
                {
                    Id = source.Id,
                    Name = source.Name,
                    CreateDate = source.CreateDate,
                    ModifiedDate = source.ModifiedDate,
                    Description = source.Description,
                    BrandId = source.BrandId,
                    Price = source.Price,
                    active = source.active,
                    Featured = source.Featured,
                    SKU = source.SKU,
            };

            return product;
        }
    }
}
