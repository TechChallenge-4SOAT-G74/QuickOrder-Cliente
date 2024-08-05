using QuickOrderCliente.Domain.Enums;
using QuickOrderCliente.Domain.ValueObjects;

namespace QuickOrderCliente.Domain.Entities
{
    public class Cliente : EntityBase, IAggregateRoot
    {
        protected Cliente() { }

        protected Cliente(string nome, DateTime dataNascimento, ESexo sexo, EnderecoVo endereco) 
        { 
            Nome = nome;
            DataNascimento = DataNascimento;
            Endereco = endereco;
            Sexo = sexo;

            Validar();
        }

        public string Nome { get; set; }
        public DateTime DataNascimento{ get; set; }
        public virtual EnderecoVo Endereco { get; set; }
        public ESexo Sexo { get; set; }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome)) { throw new Exception("Nome não informado!"); }
            if (Nome.Length < 8) { throw new Exception("Nome deve ter pelo menos 3 caracteres!"); }
            if (Endereco == null ) { throw new Exception("Endereço não informado!"); }
        }
    }
}
