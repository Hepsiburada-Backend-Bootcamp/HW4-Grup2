using HW4_Grup2.Domain.Entities;
using HW4_Grup2.Domain.Repositories;
using HW4_Grup2.Infrastructure.Context;

namespace HW4_Grup2.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public UserRepository(AppDbContext context) : base(context)
        {

        }
    }
}
