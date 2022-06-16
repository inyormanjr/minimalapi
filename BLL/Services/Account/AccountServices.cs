
using AutoMapper;
using BLL.DTO.Users;
using BLL.Extensions;
using DAL.IRepositories;
using Domain.DomainAgg.UserAgg;

namespace BLL.Services.Account
{
	public class AccountServices
	{
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public AccountServices(IUserRepository userRepository, IMapper _mapper)
		{
            this.userRepository = userRepository;
            mapper = _mapper;
        }

        public async Task<UserDTO> Register(CreateUserDTO createUserDTO)
        {
            var mapped = mapper.Map<User>(createUserDTO);
            mapped.GeneratePasswordHashAndSalt(createUserDTO.Password);
            await userRepository.Save(mapped);
            var remapped = mapper.Map<UserDTO>(mapped);
            return remapped;
        }

        public async Task<UserDTO?> Login(LoginUserDTO loginUserDTO)
        {
            var user = await userRepository.GetUserByUsername(loginUserDTO.Email);
            if (user == null) return null;
            var isAuthenticateSuccess = user.AuthenticatePassword(loginUserDTO.Password);
            if (!isAuthenticateSuccess) return null;
            var mapped = mapper.Map<UserDTO>(user);
            return mapped;
        }


        
	}
}

