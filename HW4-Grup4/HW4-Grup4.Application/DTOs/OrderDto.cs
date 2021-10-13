using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup4.Application.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        //public virtual UserDto User { get; set; }
        public double TotalPrice { get; set; }
        public string Address { get; set; }
    }
}
