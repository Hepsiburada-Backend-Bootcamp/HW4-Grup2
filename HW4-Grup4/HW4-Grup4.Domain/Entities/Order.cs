using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup4.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public double TotalPrice { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
