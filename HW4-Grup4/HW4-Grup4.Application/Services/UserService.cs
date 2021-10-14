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

        public async Task Add()
        {
            //User user = new User();

            //_userMongoRepository.AddAsync(user);
            //await _userRepository.AddAsync(user);
            var result = await _userDapperRepository.GetUser(1);
            var q = 3;
        }
    }
}
