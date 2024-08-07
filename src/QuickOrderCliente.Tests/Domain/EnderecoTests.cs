using QuickOrderCliente.Domain.Entities;
using QuickOrderCliente.Domain.ValueObjects;

namespace QuickOrderCliente.Tests.Domain
{
    public class EnderecoTests
    {
        [Fact]
        public void Construtor_Deve_Criticar_Rua_Nao_Informada()
        {
            //Arrange, Act 
            var action = () => new EnderecoVo("", "1", "Rio de Janeiro", "22222222");
            var exception = Assert.Throws<Exception>(action);

            //Assert
            Assert.Equal("Rua não informada!", exception.Message);
        }

        [Fact]
        public void Construtor_Deve_Criticar_Numero_Nao_Informado()
        {
            //Arrange, Act 
            var action = () => new EnderecoVo("Rua Teste", "", "Rio de Janeiro", "22222222");
            var exception = Assert.Throws<Exception>(action);

            //Assert
            Assert.Equal("Número não informado!", exception.Message);
        }

        [Fact]
        public void Construtor_Deve_Criticar_Cidade_Nao_Informada()
        {
            //Arrange, Act 
            var action = () => new EnderecoVo("Rua Teste", "1", "", "22222222");
            var exception = Assert.Throws<Exception>(action);

            //Assert
            Assert.Equal("Cidade não informada!", exception.Message);
        }

        [Fact]
        public void Construtor_Deve_Criticar_Cep_Nao_Informado()
        {
            //Arrange, Act 
            var action = () => new EnderecoVo("Rua Teste", "1", "Rio de Janeiro", "");
            var exception = Assert.Throws<Exception>(action);

            //Assert
            Assert.Equal("CEP não informado!", exception.Message);
        }

        [Fact]
        public void Construtor_Deve_Criticar_Cep_Quantidade_Caracteres_Invalidos()
        {
            //Arrange, Act 
            var action = () => new EnderecoVo("Rua Teste", "1", "Rio de Janeiro", "222");
            var exception = Assert.Throws<Exception>(action);

            //Assert
            Assert.Equal("CEP deve ter 8 caracteres!", exception.Message);
        }
    }
}
