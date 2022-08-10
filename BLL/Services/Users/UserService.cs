using System;
using AutoMapper;
using BLL.DTO.Users;
using DAL.IRepositories;
using Domain.DomainAgg.UserAgg;

namespace BLL.Services.Users
{
	public class UserService
	{
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
		{
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public  async Task<List<UserDTO>> GetMany(int skip, int take)
        {
            var result = await this.userRepository.GetList(skip, take);
            var mapped = this.mapper.Map<List<UserDTO>>(result);
            return mapped;
        }

        public async Task<UserDTO> GetById(int id)
        {
            var result = await this.userRepository.GetById(id);
            var mapped = this.mapper.Map<UserDTO>(result);
            return mapped;
        }

        public async Task<UserDTO?> Update(int id, UserDTO userDTO)
        {
            var checkedUser = await this.userRepository.GetById(id);
            if (checkedUser == null) return null;
             var merged  = mapper.Map(userDTO, checkedUser);
            var result = await this.userRepository.Update(id, merged);
            var remapped = mapper.Map<UserDTO>(result);
            return remapped;
        }

        public async Task<bool> Delete(int id)
        {
             var result = await this.userRepository.Delete(id);
            return result;
        }
	}
}

