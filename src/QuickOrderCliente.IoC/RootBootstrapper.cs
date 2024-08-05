using Microsoft.Extensions.DependencyInjection;
using QuickOrderCliente.Application.UseCases.Cliente;
using QuickOrderCliente.Application.UseCases.Cliente.Interfaces;
using QuickOrderCliente.Domain.Adapters;
using QuickOrderCliente.PostgresDB.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace QuickOrderCliente.IoC
{
    [ExcludeFromCodeCoverage]
    public static class RootBootstrapper
    {
        public static void BootstrapperRegisterServices(this IServiceCollection services)
        {
            var assemblyTypes = typeof(RootBootstrapper).Assembly.GetNoAbstractTypes();

            services.AddImplementations(ServiceLifetime.Scoped, typeof(IBaseRepository), assemblyTypes);


            //Repositories postgresDB

            services.AddScoped<IClienteRepository, ClienteRepository>();


            //UseCases
            services.AddScoped<IClienteAtualizarUseCase, ClienteAtualizarUseCase>();
            services.AddScoped<IClienteExcluirUseCase, ClienteExcluirUseCase>();
            services.AddScoped<IClienteCriarUseCase, ClienteCriarUseCase>();
            services.AddScoped<IClienteObterUseCase, ClienteObterUseCase>();
        }
    }
}