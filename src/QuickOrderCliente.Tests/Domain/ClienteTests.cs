using QuickOrderCliente.Domain.Entities;
using QuickOrderCliente.Domain.ValueObjects;

namespace QuickOrderCliente.Tests.Domain
{
    public class ClienteTests
    {
        [Fact]
        public void Construtor_Deve_Criticar_Cpf_Nao_Informado()
        {
            //Arrange
            var enderecoVo = new EnderecoVo("Rua Teste", "1", "Rio de Janeiro", "22222222");

            //Act 
            var action = () => new Cliente("José Carlos", new DateTime(2000, 05, 12), "", 1, enderecoVo);
            var exception = Assert.Throws<Exception>(action);

            //Assert
            Assert.Equal("CPF não informado!", exception.Message);
        }

        [Fact]
        public void Construtor_Deve_Criticar_Nome_Nao_Informado()
        {
            //Arrange
            var enderecoVo = new EnderecoVo("Rua Teste", "1", "Rio de Janeiro", "22222222");

            //Act 
            var action = () => new Cliente("", new DateTime(2000, 05, 12), "11111111111", 1, enderecoVo);
            var exception = Assert.Throws<Exception>(action);

            //Assert
            Assert.Equal("Nome não informado!", exception.Message);
        }

        [Fact]
        public void Construtor_Deve_Criticar_Nome_Com_Menos_Caracteres_Que_Permitido()
        {
            //Arrange
            var enderecoVo = new EnderecoVo("Rua Teste", "1", "Rio de Janeiro", "22222222");

            //Act 
            var action = () => new Cliente("Jos", new DateTime(2000, 05, 12), "11111111111", 1, enderecoVo);
            var exception = Assert.Throws<Exception>(action);

            //Assert
            Assert.Equal("Nome deve ter pelo menos 3 caracteres!", exception.Message);
        }

        [Fact]
        public void Construtor_Deve_Criticar_Cpf_Com_Menos_Caracteres_Que_Permitido()
        {
            //Arrange
            var enderecoVo = new EnderecoVo("Rua Teste", "1", "Rio de Janeiro", "22222222");

            //Act 
            var action = () => new Cliente("José Carlos", new DateTime(2000, 05, 12), "111", 1, enderecoVo);
            var exception = Assert.Throws<Exception>(action);

            //Assert
            Assert.Equal("CPF deve ter 11 caracteres!", exception.Message);
        }

        [Fact]
        public void Construtor_Deve_Criticar_Endereco_Nao_Informado()
        {
            //Arrange, Act 
            var action = () => new Cliente("José Carlos", new DateTime(2000, 05, 12), "11111111111", 1, null);
            var exception = Assert.Throws<Exception>(action);

            //Assert
            Assert.Equal("Endereço não informado!", exception.Message);
        }
    }
}