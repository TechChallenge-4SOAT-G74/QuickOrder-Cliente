using Moq;
using QuickOrderCliente.Application.UseCases.Cliente;
using QuickOrderCliente.Domain.Adapters;
using QuickOrderCliente.Domain.Entities;
using QuickOrderCliente.Domain.ValueObjects;

namespace QuickOrderCliente.Tests.UseCase
{
    public class ClienteObterUseCaseTests
    {
        private readonly Mock<IClienteRepository> _clienteRepositoryMock;
        private readonly ClienteObterUseCase _clienteObterUseCase;

        public ClienteObterUseCaseTests()
        {
            _clienteRepositoryMock = new Mock<IClienteRepository>();
            _clienteObterUseCase = new ClienteObterUseCase(_clienteRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_ShouldReturnListOfClientes_WhenClientesExist()
        {
            // Arrange
            var enderecoVo1 = new EnderecoVo("Rua Teste", "1", "Rio de Janeiro", "11111111");
            var enderecoVo2 = new EnderecoVo("Rua Teste", "1", "Rio de Janeiro", "22222222");

            var clientes = new List<Cliente>
            {
                new Cliente("José Calos", new DateTime(2000, 05, 12), "30346888069", 1, enderecoVo1),
                new Cliente("Ana Maria", new DateTime(2000, 05, 12), "59191261678", 2, enderecoVo2),
            };

            _clienteRepositoryMock.Setup(repo => repo.GetAll(c => c.Ativo)).ReturnsAsync(clientes);

            // Act
            var result = await _clienteObterUseCase.Execute();

            // Assert
            Assert.NotNull(result.Data);
            Assert.Equal(2, result.Data.Count);
            Assert.Equal("José Calos", result.Data[0].Nome);
            Assert.Equal("Ana Maria", result.Data[1].Nome);
        }

        [Fact]
        public async Task Execute_ShouldReturnCliente_WhenClienteExists()
        {
            // Arrange
            var enderecoVo1 = new EnderecoVo("Rua Teste", "1", "Rio de Janeiro", "11111111");
            var cliente = new Cliente("José Calos", new DateTime(2000, 05, 12), "30346888069", 1, enderecoVo1);

            _clienteRepositoryMock.Setup(repo => repo.GetFirst(c => c.Id == 1 && c.Ativo)).ReturnsAsync(cliente);

            // Act
            var result = await _clienteObterUseCase.Execute(1);

            // Assert
            Assert.NotNull(result.Data);
            Assert.Equal("José Calos", result.Data.Nome);
            Assert.Equal("30346888069", result.Data.Cpf);
            Assert.Equal("Masculino", result.Data.Sexo);
        }
    }
}
