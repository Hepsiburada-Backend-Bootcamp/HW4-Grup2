using HW4_Grup4.Domain.Entities;
using HW4_Grup4.Domain.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup4.Infrastructure.Repositories
{
    public class OrderDetailMongoRepository : MongoRepository<OrderDetail>, IOrderDetailMongoRepository
    {
        public OrderDetailMongoRepository(IMongoDbContext context) : base(context)
        {

        }
    }
}
