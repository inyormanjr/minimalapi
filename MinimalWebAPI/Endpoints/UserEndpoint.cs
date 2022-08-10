using System;
using BLL.DTO.Users;
using BLL.Services.Users;

namespace MinimalWebAPI.WebApp.Endpoints
{
	public static class UserEndpoint
	{
		public static void MapUserEndpoint(this WebApplication app)
        {
			app.MapGet("/users", async (UserService userService, int skip, int take) => {
				var result = await userService.GetMany(skip, take);
				return Results.Ok(result);
			}).Produces<List<UserDTO>>();

			app.MapGet("/users/{id}", async (UserService userService, int id) =>
            {
				var result = await userService.GetById(id);
				if (result == null) return Results.NotFound("No User found");
				return Results.Ok(result);
            }).Produces<UserDTO>();

			app.MapPut("/users/{id}", async (UserService userService,int id, UserDTO userDTO) =>
			{
				UserDTO? result = await userService.Update(id, userDTO);
				Results.Ok(result);
			}).Produces<UserDTO>();

			app.MapDelete("/users/{id}", async (UserService userService, int id) =>
            {
				var result = await userService.Delete(id);
				return Results.Ok(result);
            }).Produces<bool>();
        }
	}
}

