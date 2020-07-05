using FI.AtividadeEntrevista.DML.Common;

namespace FI.AtividadeEntrevista.DML
{
    public class Beneficiario : Entidade<Beneficiario>
    {        
        #region Properties
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public int ClienteId { get; private set; }
        #endregion

        #region Constructor
        protected Beneficiario() { }

        public Beneficiario(string nome, string cpf, int clientId)
        {
            Nome = nome;
            CPF = cpf;
            ClienteId = clientId;
        }
        #endregion

        #region Factory
        public static Beneficiario Create(string nome, string cpf, int clienteId) => 
            new Beneficiario(
                nome: nome,
                cpf: cpf,
                clientId: clienteId
            );
        #endregion
    }
}
