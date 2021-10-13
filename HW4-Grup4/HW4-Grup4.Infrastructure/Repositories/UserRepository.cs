using HW4_Grup4.Domain.Entities;
using HW4_Grup4.Domain.Repositories;
using HW4_Grup4.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup4.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public UserRepository(AppDbContext context) : base(context)
        {

        }
    }
}
