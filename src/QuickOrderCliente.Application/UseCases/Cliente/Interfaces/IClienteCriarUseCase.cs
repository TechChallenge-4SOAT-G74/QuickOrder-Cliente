using QuickOrderCliente.Application.Dtos;

namespace QuickOrderCliente.Application.UseCases.Cliente.Interfaces
{
    public interface IClienteCriarUseCase
    {
        Task<ServiceResult> Execute(ClienteDto produto);
    }
}
