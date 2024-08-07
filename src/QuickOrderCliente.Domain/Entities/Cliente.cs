using QuickOrderCliente.Domain.ValueObjects;

namespace QuickOrderCliente.Domain.Entities
{
    public class Cliente : EntityBase, IAggregateRoot
    {
        protected Cliente() { }

        public Cliente(string nome, DateTime dataNascimento, string cpf, int sexo, EnderecoVo endereco) 
        { 
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Endereco = endereco;
            Sexo = sexo;

            Validar();
        }

        public string Nome { get; set; }
        public DateTime DataNascimento{ get; set; }
        public string Cpf { get; set; }
        public virtual EnderecoVo Endereco { get; set; }
        public int Sexo { get; set; }
        public bool Ativo { get; set; } = true;

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome)) { throw new Exception("Nome não informado!"); }
            if (string.IsNullOrWhiteSpace(Cpf)) { throw new Exception("CPF não informado!"); }
            if (Nome.Length < 8) { throw new Exception("Nome deve ter pelo menos 3 caracteres!"); }
            if (Cpf.Length < 11) { throw new Exception("CPF deve ter 11 caracteres!"); }
            if (Endereco == null ) { throw new Exception("Endereço não informado!"); }
        }
    }
}
