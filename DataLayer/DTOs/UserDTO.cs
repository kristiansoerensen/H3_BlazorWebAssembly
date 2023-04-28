using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? BillingAddressId { get; set; }
    }
}
