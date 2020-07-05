using FI.AtividadeEntrevista.Web.Commands;

namespace FI.AtividadeEntrevista.DAL.Beneficiarios.Commands
{
    public class AlterarBeneficiarioCommand : ICommand
    {
        public int Id { get; }
        public string Nome { get; }
        public string CPF { get; }
        public int ClienteId { get; }

        public AlterarBeneficiarioCommand(int id, string nome, string cpf, int clienteId)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            ClienteId = clienteId;
        }
    }
}
