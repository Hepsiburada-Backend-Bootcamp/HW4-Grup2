using HW4_Grup4.Application.DTOs;
using HW4_Grup4.Application.ServiceInterfaces;
using HW4_Grup4.Domain.Repositories;
using System.Threading.Tasks;

namespace HW4_Grup4.Application.Services
{
    public class UserService : IUserService
    {
        //private readonly IUserMongoRepository _userMongoRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserDapperRepository _userDapperRepository;

        public UserService(IUserMongoRepository userMongoRepository, IUserRepository userRepository, IUserDapperRepository userDapperRepository)
        {
            //_userMongoRepository = userMongoRepository;
            _userRepository = userRepository;
            _userDapperRepository = userDapperRepository;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var result = await _userDapperRepository.GetUserById(id);

            var userDto = new UserDto { Id = result.Id, LastName = result.LastName, Name = result.Name };

            return userDto;
        }
    }
}
