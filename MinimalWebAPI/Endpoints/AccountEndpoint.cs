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
			//registration endpoint
			app.MapPost("/account/register", async (AccountServices accountService, CreateUserDTO createUser) => {
				var result = await accountService.Register(createUser);
				return Results.Ok(result);
			}).Produces<UserDTO>();


			//login endpoint
			app.MapPost("/account/login", async (AccountServices accountService, LoginUserDTO loginUserDTO) =>
			{
				var user = await accountService.Login(loginUserDTO);
				if (user == null) return Results.BadRequest("Invalid user credentials");
				var token = JWTTokenHelper.CreateToken(user, app.Configuration);
				LoginResponseUserDTO responseUserDTO = new() { Email = user.Email, Token = token };
				return Results.Ok(responseUserDTO);

			}).Produces<LoginResponseUserDTO>();
        }
	}
}

