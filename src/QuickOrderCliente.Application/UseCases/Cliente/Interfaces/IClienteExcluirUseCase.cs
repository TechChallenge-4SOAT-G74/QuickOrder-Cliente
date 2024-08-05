using QuickOrderCliente.Application.Dtos;

namespace QuickOrderCliente.Application.UseCases.Cliente.Interfaces
{
    public interface IClienteExcluirUseCase
    {
        Task<ServiceResult> Execute(int id);
    }
}