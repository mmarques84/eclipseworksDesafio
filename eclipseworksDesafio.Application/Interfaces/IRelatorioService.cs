using eclipseworksDesafio.Application.Dtos.Relatorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Application.Interfaces
{
    public interface IRelatorioService
    {
        Task<RelatorioDesempenhoDto> GerarRelatorioDesempenho();
    }
}
