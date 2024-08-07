using QuickOrderCliente.Application.Dtos;
using QuickOrderCliente.Application.UseCases.Cliente.Interfaces;
using QuickOrderCliente.Domain.Adapters;
using QuickOrderCliente.Domain.Enums;
using QuickOrderCliente.Domain.ValueObjects;
using ClienteEntity = QuickOrderCliente.Domain.Entities.Cliente;

namespace QuickOrderCliente.Application.UseCases.Cliente
{
    public class ClienteCriarUseCase : IClienteCriarUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteCriarUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ServiceResult> Execute(ClienteDto clienteViewModel)
        {
            ServiceResult result = new();

            try
            {
                var clienteExiste = await _clienteRepository.GetFirst(x => x.Nome.Equals(clienteViewModel.Nome));

                if (clienteExiste != null)
                {
                    result.AddError("Cliente já existe.");
                    return result;
                }

                var enderecoVo = new EnderecoVo(clienteViewModel.Rua, clienteViewModel.Numero, clienteViewModel.Cidade, clienteViewModel.Cep);

                var cliente = new ClienteEntity(
                    clienteViewModel.Nome,
                    clienteViewModel.DataNascimento,
                    clienteViewModel.Cpf,
                    (int)(ESexo)Enum.Parse(typeof(ESexo), clienteViewModel.Sexo),
                    enderecoVo
                    );

                var clienteInsert = await _clienteRepository.Insert(cliente);
            }
            catch (Exception ex) { result.AddError(ex.Message); }

            return result;
        }
    }
}
