using QuickOrderCliente.Application.Dtos;
using QuickOrderCliente.Application.UseCases.Cliente.Interfaces;
using QuickOrderCliente.Domain.Adapters;

namespace QuickOrderCliente.Application.UseCases.Cliente
{
    public class ClienteExcluirUseCase : IClienteExcluirUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteExcluirUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ServiceResult> Execute(int id)
        {
            ServiceResult result = new();

            try
            {
                var clienteExiste = await _clienteRepository.GetFirst(id);

                if (clienteExiste == null)
                {
                    result.AddError("Cliente não encontrado.");
                    return result;
                }

                await _clienteRepository.Delete(id);
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}
