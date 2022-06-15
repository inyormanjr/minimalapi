using System;
using BLL.DTO.Users;
using BLL.Services.Account;
using MinimalWebAPI.WebApp.Helpers;

namespace MinimalWebAPI.Endpoints
{
	public static class AccountEndpoint
	{
		public static void MapAccountEndPoint(this WebApplication app)
        {
			app.MapPost("/account/register", async (AccountServices accountService, CreateUserDTO createUser) => {
				var result = await accountService.Register(createUser);
				return Results.Ok(result);
			}).Produces<UserDTO>();

			app.MapPost("/account/login", async (AccountServices accountService, LoginUserDTO loginUserDTO) =>
			{
				var user = await accountService.Login(loginUserDTO);
				var token = JWTTokenHelper.CreateToken(user, app.Configuration);
				LoginResponseUserDTO responseUserDTO = new() { Email = user.Email, Token = token };
				return Results.Ok(responseUserDTO);
			}).Produces<LoginResponseUserDTO>().ProducesProblem(500, "Invalid User Credentials");
        }
	}
}

