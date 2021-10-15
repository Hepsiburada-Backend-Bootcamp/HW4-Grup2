using HW4_Grup2.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW4_Grup2.Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(int id);
        Task<List<UserDto>> GetAllAsync();
    }
}
