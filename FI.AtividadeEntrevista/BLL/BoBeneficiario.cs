using FI.AtividadeEntrevista.DAL.Beneficiarios.Commands;
using FI.AtividadeEntrevista.DAL.Beneficiarios.Handlers;
using FI.AtividadeEntrevista.Utils;
using FI.AtividadeEntrevista.Web.Commands;
using FI.AtividadeEntrevista.Web.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario : DataResult
    {
        private readonly IncluirBeneficiarioDao _incluir;
        private readonly AtualizarBeneficiarioDao _alterar;
        private readonly DeletarBeneficiarioDao _deletar;

        public BoBeneficiario()
        {
            _incluir = new IncluirBeneficiarioDao();
            _alterar = new AtualizarBeneficiarioDao();
            _deletar = new DeletarBeneficiarioDao();
        }

        #region Public Methods
        public DataResult Executar(ICommand command)
        {
            var handlers = new Dictionary<string, Func<DataResult>>
            {
                {  typeof(IncluirBeneficiarioCommand).Name, IncluirBeneficiario(command) },
                {  typeof(AlterarBeneficiarioCommand).Name, AlterarBeneficiario(command) },
                {  typeof(DeletarBeneficiarioCommand).Name, DeletarBeneficiario(command) }
            };

            var handler = handlers[command.GetType().Name];
            if (handler != null)
            {
                var result = handlers[command.GetType().Name].Invoke();
                return result;
            }

            GenerateLocalError(500 /* Internal Server Error */, "Houve um erro interno não identificado.");
            return this;
        }
        #endregion

        #region Private Methods
        private Func<DataResult> IncluirBeneficiario(ICommand command) => 
            new Func<DataResult>(() => 
            {
                if (!Validations.CPF.Validate(((IncluirBeneficiarioCommand)command).CPF))
                {
                    GenerateLocalError(404, "O CPF informado é inválido.");
                    return this;
                }

                if (_incluir.VerificarExistencia(((IncluirBeneficiarioCommand)command).CPF))
                {
                    GenerateLocalError(404, "Já existe um benefiário cadastrado com este CPF.");
                    return this;
                }

                return _incluir.Hander((IncluirBeneficiarioCommand)command); 
            });

        private Func<DataResult> AlterarBeneficiario(ICommand command) => 
            new Func<DataResult>(() =>
            {
                if (!Validations.CPF.Validate(((IncluirBeneficiarioCommand)command).CPF))
                {
                    GenerateLocalError(404, "O CPF informado é inválido.");
                    return this;
                }

                if (_incluir.VerificarExistencia(((IncluirBeneficiarioCommand)command).CPF))
                {
                    GenerateLocalError(404, "Já existe um benefiário cadastrado com este CPF.");
                    return this;
                }

                return _alterar.Hander((AlterarBeneficiarioCommand)command);
            });

        private Func<DataResult> DeletarBeneficiario(ICommand command) => 
            new Func<DataResult>(() => _deletar.Hander((DeletarBeneficiarioCommand)command));
        #endregion
    }
}
