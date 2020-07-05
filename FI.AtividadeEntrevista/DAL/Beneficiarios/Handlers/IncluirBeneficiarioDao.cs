using FI.AtividadeEntrevista.DAL.Beneficiarios.Commands;
using FI.AtividadeEntrevista.Utils;
using FI.AtividadeEntrevista.Web.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.DAL.Beneficiarios.Handlers
{
    internal class IncluirBeneficiarioDao : AcessoDados
    {
        public CommandResult Hander(IncluirBeneficiarioCommand command)
        {
            var result = new CommandResult();

            result.RegisterData(new { Id = Register(command) });
            return result;
        }

        private long Register(IncluirBeneficiarioCommand command)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("NOME", command.Nome));
            parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", command.CPF));
            parametros.Add(new System.Data.SqlClient.SqlParameter("IDCLIENTE", command.ClienteId));

            DataSet ds = base.Consultar("FI_SP_IncBeneficiario", parametros);
            long result = 0;
            if (ds.Tables[0].Rows.Count > 0)
                long.TryParse(ds.Tables[0].Rows[0][0].ToString(), out result);

            return result;
        }

        internal bool VerificarExistencia(string CPF)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", CPF));

            DataSet ds = Consultar("FI_SP_VerificaBeneficiario", parametros);

            return ds.Tables[0].Rows.Count > 0;
        }
    }
}
