using QuickOrderCliente.Application.Dtos;
using QuickOrderCliente.Application.UseCases.Cliente.Interfaces;
using QuickOrderCliente.Domain.Adapters;
using QuickOrderCliente.Domain.Enums;

namespace QuickOrderCliente.Application.UseCases.Cliente
{
    public class ClienteAtualizarUseCase : IClienteAtualizarUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteAtualizarUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ServiceResult> Execute(ClienteDto clienteViewModel, int id)
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

                clienteExiste.Sexo = (int)(ESexo)Enum.Parse(typeof(ESexo), clienteViewModel.Sexo);
                clienteExiste.Nome = clienteViewModel.Nome;
                clienteExiste.DataNascimento = clienteViewModel.DataNascimento;
                clienteExiste.Endereco.Rua = clienteViewModel.Rua;
                clienteExiste.Endereco.Cidade = clienteViewModel.Cidade;
                clienteExiste.Endereco.Cep = clienteViewModel.Cep;
                clienteExiste.Endereco.Numero = clienteViewModel.Numero;

                await _clienteRepository.Update(clienteExiste);
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
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

                clienteExiste.Ativo = false;

                await _clienteRepository.Update(clienteExiste);
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}
