using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Application.Dtos.Relatorio
{
    public class RelatorioDesempenhoDto
    {
        public double MediaTarefasConcluidas { get; set; }
        public DateTime dataSolicitacao { get; set; }
        public string responsalvel { get; set; }
    }
}
