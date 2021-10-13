using HW4_Grup4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup4.Domain.Repositories
{
    public interface IOrderDetailMongoRepository : IMongoRepository<OrderDetail>
    {
    }
}
