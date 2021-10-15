using HW4_Grup2.Domain.Entities;
using HW4_Grup2.Domain.Repositories;
using HW4_Grup2.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup2.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public OrderRepository(AppDbContext context) : base(context)
        {

        }
    }
}
