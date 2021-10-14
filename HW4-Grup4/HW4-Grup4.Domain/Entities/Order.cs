using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup4.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public double TotalPrice { get; set; }

        public string Address { get; set; }

        public int OrderNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
