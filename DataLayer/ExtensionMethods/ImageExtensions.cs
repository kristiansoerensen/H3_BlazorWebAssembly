using DataLayer.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ExtensionMethods
{
    public static class ImageExtensions
    {
        //used by LINQ to SQL
        public static IEnumerable<ImageDTO> ToDTOs(this IQueryable<Image> source)
        {
            List<Image> items = source.ToList();
            List<ImageDTO> DTOs = new List<ImageDTO>();
            foreach (Image item in items)
            {
                DTOs.Add(new ImageDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    Filename = item.Filename,
                    ProductId = item.ProductId,
                    CategoryIds = item.Categories?.Select(i => i.Id).ToList()
                });
            }
            return DTOs;
        }

        //used by LINQ to Linq
        public static IEnumerable<ImageDTO> ToDTOs(this IEnumerable<Image> source)
        {
            List<ImageDTO> DTOs = new List<ImageDTO>();
            foreach (Image item in source)
            {
                DTOs.Add(new ImageDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    Filename = item.Filename,
                    ProductId = item.ProductId,
                    CategoryIds = item.Categories?.Select(i => i.Id).ToList()
                });
            }
            return DTOs;
        }

        public static Image FromDTO(this ImageDTO source)
        {
            Image item = new Image
            {
                Id = source.Id,
                Name = source.Name,
                CreateDate = source.CreateDate,
                ModifiedDate = source.ModifiedDate,
                Filename = source.Filename,
                ProductId = source.ProductId
            };

            return item;
        }
    }
}
