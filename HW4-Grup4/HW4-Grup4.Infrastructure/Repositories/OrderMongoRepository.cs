using HW4_Grup4.Domain.Entities;
using HW4_Grup4.Domain.Repositories;

namespace HW4_Grup4.Infrastructure.Repositories
{
    public class OrderMongoRepository : MongoRepository<OrderDetail>, IOrderMongoRepository
    {
        public OrderMongoRepository(IMongoDbContext context) : base(context)
        {

        }
    }
}
