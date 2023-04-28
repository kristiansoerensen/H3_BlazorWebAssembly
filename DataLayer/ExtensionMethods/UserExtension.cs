using DataLayer.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ExtensionMethods
{
    public static class UserExtension
    {
        //used by LINQ to SQL
        public static IEnumerable<UserDTO> ToDTOs(this IQueryable<User> source)
        {
            List<User> items = source.ToList();
            List<UserDTO> DTOs = new List<UserDTO>();
            foreach (User item in items)
            {
                DTOs.Add(new UserDTO
                {
                    Id = item.Id,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    BillingAddressId = item.BillingAddressId,
                });
            }
            return DTOs;
        }

        //used by LINQ to Linq
        public static IEnumerable<UserDTO> ToDTOs(this IEnumerable<User> source)
        {
            List<UserDTO> DTOs = new List<UserDTO>();
            foreach (User item in source)
            {
                DTOs.Add(new UserDTO
                {
                    Id = item.Id,
                    CreateDate = item.CreateDate,
                    ModifiedDate = item.ModifiedDate,
                    BillingAddressId = item.BillingAddressId,
                });
            }
            return DTOs;
        }

        public static User FromDTO(this UserDTO source)
        {
            User item = new User
            {
                Id = source.Id,
                CreateDate = source.CreateDate,
                ModifiedDate = source.ModifiedDate,
                BillingAddressId = source.BillingAddressId,
            };

            return item;
        }
    }
}
