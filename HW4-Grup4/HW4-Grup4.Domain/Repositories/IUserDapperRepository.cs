using HW4_Grup4.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW4_Grup4.Domain.Repositories
{
    public interface IUserDapperRepository : IDapperRepository<User>
    {
        Task<List<User>> GetUser(int id);
    }
}
