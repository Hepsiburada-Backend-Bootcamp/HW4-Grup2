using HW4_Grup4.Domain.Entities;
using HW4_Grup4.Domain.Repositories;
using HW4_Grup4.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup4.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserMongoRepository _mongoRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IUserMongoRepository mongoRepository, IUserRepository userRepository)
        {
            _mongoRepository = mongoRepository;
            _userRepository = userRepository;
        }

        public async Task Add()
        {
            User user = new User();

            _mongoRepository.AddAsync(user);
            await _userRepository.AddAsync(user);
        }
    }
}
