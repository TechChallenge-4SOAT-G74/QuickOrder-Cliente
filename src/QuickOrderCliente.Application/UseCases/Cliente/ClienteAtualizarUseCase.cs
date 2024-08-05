using QuickOrderCliente.Application.Dtos;
using QuickOrderCliente.Application.UseCases.Cliente.Interfaces;

namespace QuickOrderCliente.Application.UseCases.Cliente
{
    public class ClienteAtualizarUseCase : IClienteAtualizarUseCase
    {
        public Task<ServiceResult> Execute(ClienteDto produto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
