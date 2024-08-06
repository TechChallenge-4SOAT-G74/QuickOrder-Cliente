using Microsoft.AspNetCore.Mvc;
using QuickOrderCliente.Application.Dtos;
using QuickOrderCliente.Application.UseCases.Cliente.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace QuickOrderCliente.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class EndpointsControleConfig
    {
        public static void RegisterProdutoEndpoints(this WebApplication app)
        {
            app.MapGet("/GetAll", async ([FromServices] IClienteObterUseCase clienteObterUseCase) =>
            {
                return Results.Ok(await clienteObterUseCase.Execute());
            });

            app.MapGet("/Get", async ([FromServices] IClienteObterUseCase clienteObterUseCase, int id) =>
            {
                return Results.Ok(await clienteObterUseCase.Execute(id));
            });

            app.MapPost("/Post", async ([FromServices] IClienteCriarUseCase clienteCriarUseCase, [FromBody] ClienteDto cliente) =>
            {
                return Results.Ok(await clienteCriarUseCase.Execute(cliente));
            });

            app.MapPost("/Put", async ([FromServices] IClienteAtualizarUseCase clienteAtualizarUseCase, [FromBody] ClienteDto cliente, int id) =>
            {
                return Results.Ok(await clienteAtualizarUseCase.Execute(cliente, id));
            });

            app.MapGet("/Delete", async ([FromServices] IClienteExcluirUseCase clienteExcluirUseCase, int id) =>
            {
                return Results.Ok(await clienteExcluirUseCase.Execute(id));
            });
        }
    }
}
