using Moq;
using QuickOrderCliente.Application.Dtos;
using QuickOrderCliente.Application.UseCases.Cliente;
using QuickOrderCliente.Domain.Adapters;
using QuickOrderCliente.Domain.Entities;
using QuickOrderCliente.Domain.ValueObjects;

namespace QuickOrderCliente.Tests.UseCase
{
    public class ClienteExcluirUseCaseTests
    {
        private readonly Mock<IClienteRepository> _clienteRepositoryMock;
        private readonly ClienteExcluirUseCase _clienteExcluirUseCase;

        public ClienteExcluirUseCaseTests()
        {
            _clienteRepositoryMock = new Mock<IClienteRepository>();
            _clienteExcluirUseCase = new ClienteExcluirUseCase(_clienteRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_ClienteExiste_DeveExcluirCliente()
        {
            // Arrange
            int clienteId = 1;

            var enderecoVo = new EnderecoVo("Rua Teste", "1", "Rio de Janeiro", "11111111");
            var cliente = new Cliente("José Calos", new DateTime(2000, 05, 12), "30346888069", 1, enderecoVo);

            _clienteRepositoryMock.Setup(repo => repo.GetFirst(clienteId))
                                  .ReturnsAsync(cliente);
            _clienteRepositoryMock.Setup(repo => repo.Delete(clienteId))
                                  .Returns(Task.CompletedTask);

            // Act
            var result = await _clienteExcluirUseCase.Execute(clienteId);

            // Assert
            Assert.False(result.Errors.Any());
            _clienteRepositoryMock.Verify(repo => repo.GetFirst(clienteId), Times.Once);
            _clienteRepositoryMock.Verify(repo => repo.Delete(clienteId), Times.Once);
        }

        [Fact]
        public async Task Execute_RepositoryLancaExcecao_DeveRetornarErro()
        {
            // Arrange
            int clienteId = 1;
            _clienteRepositoryMock.Setup(repo => repo.GetFirst(clienteId))
                                  .ThrowsAsync(new Exception("Erro no repositório"));

            // Act
            var result = await _clienteExcluirUseCase.Execute(clienteId);

            // Assert
            Assert.True(result.Errors.Any());
            Assert.Contains("Erro no repositório", result.Errors.FirstOrDefault().Message);
            _clienteRepositoryMock.Verify(repo => repo.GetFirst(clienteId), Times.Once);
            _clienteRepositoryMock.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}
