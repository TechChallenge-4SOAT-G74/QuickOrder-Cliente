using QuickOrderCliente.Application.Dtos;
using QuickOrderCliente.Application.UseCases.Cliente.Interfaces;

namespace QuickOrderCliente.Application.UseCases.Cliente
{
    public class ClienteCriarUseCase : IClienteCriarUseCase
    {
        public Task<ServiceResult> Execute(ClienteDto produto)
        {
            throw new NotImplementedException();
        }
    }
}
