using System;
using AutoMapper;
using BLL.DTO.Users;
using Domain.DomainAgg.UserAgg;

namespace BLL.Utilities
{
	public class AutoMapperProfile:Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<User, UserDTO>();
			CreateMap<UserDTO, User>();
			CreateMap<User, CreateUserDTO>().ReverseMap();
		}
	}
}

