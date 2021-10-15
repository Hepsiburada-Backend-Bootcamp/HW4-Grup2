using AutoMapper;
using HW4_Grup4.Application.DTOs;
using HW4_Grup4.Application.ServiceInterfaces;
using HW4_Grup4.Domain.Entities;
using HW4_Grup4.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW4_Grup4.Application.Services
{
    public class UserService : IUserService
    {
        //private readonly IUserMongoRepository _userMongoRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserDapperRepository _userDapperRepository;
        private readonly IMapper _mapper;

        public UserService(IUserMongoRepository userMongoRepository, IUserRepository userRepository, IUserDapperRepository userDapperRepository, IMapper mapper)
        {
            //_userMongoRepository = userMongoRepository;
            _userRepository = userRepository;
            _userDapperRepository = userDapperRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var result = await _userDapperRepository.GetUserById(id);

            var userDto = _mapper.Map<UserDto>(result);

            return userDto;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var result = await _userRepository.GetAllAsync();

            var userList = _mapper.Map<List<User>, List<UserDto>>(result.ToList());

            return userList;
        }
    }
}
