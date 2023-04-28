using DataLayer.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ExtensionMethods
{
    public static class CountryExtensions
    {
        //used by LINQ to SQL
        public static IEnumerable<CountryDTO> ToDTOs(this IQueryable<Country> source)
        {
            List<Country> items = source.ToList();
            List<CountryDTO> DTOs = new List<CountryDTO>();
            foreach (Country item in items)
            {
                DTOs.Add(new CountryDTO
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
        public static IEnumerable<CountryDTO> ToDTOs(this IEnumerable<Country> source)
        {
            List<CountryDTO> DTOs = new List<CountryDTO>();
            foreach (Country item in source)
            {
                DTOs.Add(new CountryDTO
                {
                    Id = item.Id,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    Name = item.Name,
                });
            }
            return DTOs;
        }

        public static Country FromDTO(this CountryDTO source)
        {
            Country item = new Country
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
