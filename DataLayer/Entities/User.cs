using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class User : IdentityUser
    {
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? BillingAddressId { get; set; }
        public Address? BillingAddress { get; set; }
    }
}
