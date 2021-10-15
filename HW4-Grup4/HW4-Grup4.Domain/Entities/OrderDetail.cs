using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup4.Domain.Entities
{
    [BsonIgnoreExtraElements(Inherited = true)]
    public class OrderDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public double TotalPrice { get; set; }

        public string Address { get; set; }

        public int OrderNumber { get; set; }

        public DateTime CreatedAt { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
