using MicroApi.Models;
using MicroApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroApi.Controllers
{
    public static class ClientController
    {
        public static void MapClientEndPoints(this WebApplication app)
        {
            var service = new ClientService();

            app.MapGet("/", () => "Api dos Clientes rodando!");

            app.MapGet("/clientes", () => service.GetAll()).RequireAuthorization();

            app.MapGet("/cliente/{id:int}", (int id) =>
            {
                var newClient = service.GetById(id);
                return newClient is not null ? Results.Ok(newClient) : Results.NotFound();
            }).RequireAuthorization();

            app.MapPost("/cliente", (Client client) =>
            {
                var newClient = service.Create(client);
                return Results.Created($"/cliente/{newClient.Id}", newClient);
            }).RequireAuthorization();
        }
    }
}
