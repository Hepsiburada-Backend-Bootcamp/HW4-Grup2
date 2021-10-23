using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HW4_Grup2.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
