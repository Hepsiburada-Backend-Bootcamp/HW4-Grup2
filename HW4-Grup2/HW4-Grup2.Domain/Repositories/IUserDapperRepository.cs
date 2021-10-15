using HW4_Grup2.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW4_Grup2.Domain.Repositories
{
    public interface IUserDapperRepository : IDapperRepository<User>
    {
        Task<User> GetUserById(int id);
    }
}
