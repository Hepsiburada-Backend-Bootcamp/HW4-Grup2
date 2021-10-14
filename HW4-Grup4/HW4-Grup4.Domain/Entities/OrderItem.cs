﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW4_Grup4.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        //public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int Piece { get; set; }

        public double ItemPrice { get; set; }
    }
}