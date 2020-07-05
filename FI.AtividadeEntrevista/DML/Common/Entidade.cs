using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.DML.Common
{
    public abstract class Entidade<TEntity>
        where TEntity: class
    {
        public long Id { get; set; }
    }
}
