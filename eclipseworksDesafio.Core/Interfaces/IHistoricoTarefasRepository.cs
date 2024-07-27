using eclipseworksDesafio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Core.Interfaces
{
    public interface IHistoricoTarefasRepository
    {
        Task AdicionarHistorico(HistoricoTarefa historico);
    }
}
