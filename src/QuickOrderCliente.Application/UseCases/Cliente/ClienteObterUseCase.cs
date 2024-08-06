using QuickOrderCliente.Application.Dtos;
using QuickOrderCliente.Application.UseCases.Cliente.Interfaces;
using QuickOrderCliente.Domain.Adapters;
using QuickOrderCliente.Domain.Enums;

namespace QuickOrderCliente.Application.UseCases.Cliente
{
    public class ClienteObterUseCase : IClienteObterUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteObterUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ServiceResult<List<ClienteDto>>> Execute()
        {
            ServiceResult<List<ClienteDto>> result = new();

            try
            {
                var clientes = await _clienteRepository.GetAll(c => c.Ativo);

                var list = new List<ClienteDto>();

                foreach (var cliente in clientes)
                {
                    list.Add(new ClienteDto
                    {
                        Sexo = ESexoExtensions.ToDescriptionString((ESexo)cliente.Sexo),
                        Nome = cliente.Nome,
                        DataNascimento = cliente.DataNascimento,
                        Rua = cliente.Endereco.Rua,
                        Cidade = cliente.Endereco.Cidade,
                        Cep = cliente.Endereco.Cep,
                        Numero = cliente.Endereco.Numero
                    });
                }

                result.Data = list;
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }

        public async Task<ServiceResult<ClienteDto>> Execute(int id)
        {
            ServiceResult<ClienteDto> result = new();

            try
            {
                var cliente = await _clienteRepository.GetFirst(c => c.Id == id && c.Ativo);

                if (cliente != null)
                {
                    result.Data = new ClienteDto
                    {
                        Sexo = ESexoExtensions.ToDescriptionString((ESexo)cliente.Sexo),
                        Nome = cliente.Nome,
                        DataNascimento = cliente.DataNascimento,
                        Rua = cliente.Endereco.Rua,
                        Cidade = cliente.Endereco.Cidade,
                        Cep = cliente.Endereco.Cep,
                        Numero = cliente.Endereco.Numero
                    };
                }
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}
