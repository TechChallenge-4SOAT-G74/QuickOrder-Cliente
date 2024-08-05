namespace QuickOrderCliente.Domain.ValueObjects
{
    public class EnderecoVo
    {
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }

        public EnderecoVo(string rua, string numero, string cidade, string cep)
        {
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Cep = cep;
            Validar();
        }

        protected EnderecoVo() { }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Rua)) { throw new Exception("Rua não informada!"); }
            if (string.IsNullOrWhiteSpace(Numero)) { throw new Exception("Número não informado!"); }
            if (string.IsNullOrWhiteSpace(Cidade)) { throw new Exception("Cidade não informada!"); }
            if (string.IsNullOrWhiteSpace(Cep)) { throw new Exception("CEP não informado!"); }
            
            if (Cep.Length < 8) { throw new Exception("CEP deve ter 8 caracteres!"); }
        }
    }
}
