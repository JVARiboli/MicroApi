using MicroApi.Models;
using MicroApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public static class ClientController
    {
        public static void MapClientEndPoints(this WebApplication app)
        {
            var service = new ClientService();

            app.MapGet("/", () => "Api dos Clientes rodando!");

            app.MapGet("/clientes", () => service.GetAll());

            app.MapGet("/cliente/{id:int}", (int id) =>
            {
                var newClient = service.GetById(id);
                return newClient is not null ? Results.Ok(newClient) : Results.NotFound();
            });

            app.MapPost("/cliente", (Client client) =>
            {
                var newClient = service.Create(client);
                return Results.Created($"/cliente/{newClient.Id}", newClient);
            });

            app.MapPost("/login", ([FromBody] User user) =>
            {
                if (user.Username == "admin" && user.Password == "1234")
                {
                    var token = TokenService.GenerateToken(user.Username, "my-Key");
                    return Results.Ok(new { token });
                }

                return Results.Unauthorized();
            });
        }
    }
}
