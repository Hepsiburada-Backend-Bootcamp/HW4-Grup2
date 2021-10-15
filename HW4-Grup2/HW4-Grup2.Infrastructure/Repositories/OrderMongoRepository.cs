using HW4_Grup2.Domain.Entities;
using HW4_Grup2.Domain.Repositories;

namespace HW4_Grup2.Infrastructure.Repositories
{
    public class OrderMongoRepository : MongoRepository<OrderDetail>, IOrderMongoRepository
    {
        public OrderMongoRepository(IMongoDbContext context) : base(context)
        {

        }
    }
}
