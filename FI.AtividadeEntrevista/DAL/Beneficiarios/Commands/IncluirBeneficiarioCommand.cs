using FI.AtividadeEntrevista.Web.Commands;

namespace FI.AtividadeEntrevista.DAL.Beneficiarios.Commands
{
    public class IncluirBeneficiarioCommand : ICommand
    {
        public string Nome { get; }
        public string CPF { get; }
        public int ClienteId { get; }

        public IncluirBeneficiarioCommand(string nome, string cpf, int clienteId)
        {
            Nome = nome;
            CPF = cpf;
            ClienteId = clienteId;
        }
    }
}
