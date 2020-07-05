using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.Web.Results
{
    public class CommandResult : DataResult
    {
        public void RegisterData(dynamic data)
        {
            Data = data;
        }
    }
}
