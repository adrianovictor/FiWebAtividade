namespace FI.AtividadeEntrevista.DML
{
    /// <summary>
    /// Classe de cliente que representa o registo na tabela Cliente do Banco de Dados
    /// </summary>
    public class Cliente
    {
        #region Properties
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// CEP
        /// </summary>
        public string CEP { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public string Cidade { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        public string Logradouro { get; set; }

        /// <summary>
        /// Nacionalidade
        /// </summary>
        public string Nacionalidade { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome
        /// </summary>
        public string Sobrenome { get; set; }

        public string CPF { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        public string Telefone { get; set; }
        #endregion

        #region Constructor
        protected Cliente() { }

        public Cliente(string nome, string sobrenome, string cpf, string nacionalidade, 
            string cep, string estado, string cidade, string logradouro, string email, string telefone)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cpf;
            Nacionalidade = nacionalidade;
            CEP = cep;
            Estado = estado;
            Cidade = cidade;
            Logradouro = logradouro;
            Email = email;
            Email = email;
            Telefone = telefone;
        }
        #endregion

        #region Factory
        public static Cliente Create(string nome, string sobrenome, string cpf, string nacionalidade,
            string cep, string estado, string cidade, string logradouro, string email, string telefone) =>
                new Cliente(
                    nome: nome, 
                    sobrenome: sobrenome, 
                    cpf: cpf, 
                    nacionalidade: nacionalidade, 
                    cep: cep, 
                    estado: estado, 
                    cidade: cidade, 
                    logradouro: logradouro, 
                    email: email, 
                    telefone: telefone
                );

        #endregion

        #region Private Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
