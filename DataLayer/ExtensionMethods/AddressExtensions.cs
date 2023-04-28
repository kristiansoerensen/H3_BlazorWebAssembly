using DataLayer.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ExtensionMethods
{
    public static class AddressExtensions
    {
        //used by LINQ to SQL
        public static IEnumerable<AddressDTO> ToDTOs(this IQueryable<Address> source)
        {
            List<Address> items = source.ToList();
            List<AddressDTO> DTOs = new List<AddressDTO>();
            foreach (Address item in items)
            {
                DTOs.Add(new AddressDTO
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    Street = item.Street,
                    City = item.City,
                    Street2 = item.Street2,
                    ZipCode = item.ZipCode,
                    CountryId = item.CountryId,
                    Email = item.Email,
                    Mobile = item.Mobile
                });
            }
            return DTOs;
        }

        //used by LINQ to Linq
        public static IEnumerable<AddressDTO> ToDTOs(this IEnumerable<Address> source)
        {
            List<AddressDTO> DTOs = new List<AddressDTO>();
            foreach (Address item in source)
            {
                DTOs.Add(new AddressDTO
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    Street = item.Street,
                    City = item.City,
                    Street2 = item.Street2,
                    ZipCode = item.ZipCode,
                    CountryId = item.CountryId,
                    Email = item.Email,
                    Mobile = item.Mobile
                });
            }
            return DTOs;
        }

        public static Address FromDTO(this AddressDTO source)
        {
            Address item = new Address
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                CreateDate = source.CreateDate,
                ModifiedDate = source.ModifiedDate,
                Street = source.Street,
                City = source.City,
                Street2 = source.Street2,
                ZipCode = source.ZipCode,
                CountryId = source.CountryId,
                Email = source.Email,
                Mobile = source.Mobile
            };

            return item;
        }
    }
}
