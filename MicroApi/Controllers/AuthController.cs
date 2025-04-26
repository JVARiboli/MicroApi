using MicroApi.Models;
using MicroApi.Services;

namespace MicroApi.Controllers
{
    public static class AuthController
    {
        public static void MapAuthEndPoints(this WebApplication app, string secret)
        {
            app.MapPost("/login", (User user) =>
            {
                if (user.Username == "admin" && user.Password == "123")
                {
                    var token = TokenService.GenerateToken(user.Username, secret);
                    return Results.Ok(new { token });
                }

                return Results.Unauthorized();
            });
        }
    }
}
