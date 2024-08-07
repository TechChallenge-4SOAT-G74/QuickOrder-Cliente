using Moq;
using QuickOrderCliente.Application.Dtos;
using QuickOrderCliente.Application.UseCases.Cliente;
using QuickOrderCliente.Domain.Adapters;
using QuickOrderCliente.Domain.Entities;

namespace QuickOrderCliente.Tests.UseCase
{
    public class ClienteAtualizarUseCaseTests
    {
        private readonly Mock<IClienteRepository> _clienteRepositoryMock;
        private readonly ClienteAtualizarUseCase _clienteAtualizarUseCase;

        public ClienteAtualizarUseCaseTests()
        {
            _clienteRepositoryMock = new Mock<IClienteRepository>(); ;
            _clienteAtualizarUseCase = new ClienteAtualizarUseCase(_clienteRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_ShouldReturnError_WhenClienteNotFound()
        {
            // Arrange
            var clienteDto = new ClienteDto
            {
                Nome = "José Calos",
                Sexo = "Masculino",
                DataNascimento = new DateTime(2000, 05, 12),
                Cpf = "30346888069",
                Rua = "Rua Teste",
                Numero = "1",
                Cidade = "Rio de Janeiro",
                Cep = "11111111"
            };

            int clienteId = 1;

            _clienteRepositoryMock.Setup(repo => repo.GetFirst(It.IsAny<int>())).ReturnsAsync((Cliente)null);

            // Act
            var result = await _clienteAtualizarUseCase.Execute(clienteDto, clienteId);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Errors.Any());
            Assert.Contains("Cliente não encontrado.", result.Errors.FirstOrDefault().Message);
        }

        [Fact]
        public async Task Execute_ShouldHandleException_WhenRepositoryThrowsException()
        {
            // Arrange
            var clienteDto = new ClienteDto
            {
                Nome = "José Calos",
                Sexo = "Masculino",
                DataNascimento = new DateTime(2000, 05, 12),
                Cpf = "30346888069",
                Rua = "Rua Teste",
                Numero = "1",
                Cidade = "Rio de Janeiro",
                Cep = "11111111"
            };

            int clienteId = 1;

            _clienteRepositoryMock.Setup(repo => repo.GetFirst(It.IsAny<int>())).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _clienteAtualizarUseCase.Execute(clienteDto, clienteId);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Errors.Any());
            Assert.Contains("Database error", result.Errors.FirstOrDefault().Message);
        }
    }
}
