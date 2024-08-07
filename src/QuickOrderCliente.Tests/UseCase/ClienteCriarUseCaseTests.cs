using Moq;
using QuickOrderCliente.Application.Dtos;
using QuickOrderCliente.Application.UseCases.Cliente;
using QuickOrderCliente.Domain.Adapters;
using QuickOrderCliente.Domain.Entities;
using QuickOrderCliente.Domain.ValueObjects;
using System.Linq.Expressions;

namespace QuickOrderCliente.Tests.UseCase
{
    public class ClienteCriarUseCaseTests
    {
        [Fact]
        public async Task Execute_ClienteNaoExiste_DeveInserirCliente()
        {
            // Arrange
            var clienteRepositoryMock = new Mock<IClienteRepository>();

            clienteRepositoryMock.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Cliente, bool>>>()))
                .ReturnsAsync((Cliente)null);

            var enderecoVo1 = new EnderecoVo("Rua Teste", "1", "Rio de Janeiro", "11111111");

            clienteRepositoryMock.Setup(x => x.Insert(It.IsAny<Cliente>()))
                .ReturnsAsync(new Cliente("José Calos", new DateTime(2000, 05, 12), "30346888069", 1, enderecoVo1));

            var useCase = new ClienteCriarUseCase(clienteRepositoryMock.Object);

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

            // Act
            var result = await useCase.Execute(clienteDto);

            // Assert
            Assert.True(result.IsSuccess);
            clienteRepositoryMock.Verify(x => x.Insert(It.IsAny<Cliente>()), Times.Once);
        }

        [Fact]
        public async Task Execute_ClienteJaExiste_DeveRetornarErro()
        {
            // Arrange
            var clienteRepositoryMock = new Mock<IClienteRepository>();

            var enderecoVo = new EnderecoVo("Rua Teste", "1", "Rio de Janeiro", "11111111");

            clienteRepositoryMock.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Cliente, bool>>>()))
                .ReturnsAsync(new Cliente("José Calos", new DateTime(2000, 05, 12), "30346888069", 1, enderecoVo));

            var useCase = new ClienteCriarUseCase(clienteRepositoryMock.Object);

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

            // Act
            var result = await useCase.Execute(clienteDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Contains("Cliente já existe.", result.Errors.FirstOrDefault().Message);
        }
    }
}
