using QuickOrderCliente.Application.Dtos;

namespace QuickOrderCliente.Application.UseCases.Cliente.Interfaces
{
    public interface IClienteObterUseCase
    {
        Task<ServiceResult<List<ClienteDto>>> Execute();
        Task<ServiceResult<ClienteDto>> Execute(int id);
    }
}