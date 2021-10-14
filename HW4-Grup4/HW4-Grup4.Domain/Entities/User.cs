using System;
using System.Collections.Generic;

namespace HW4_Grup4.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
