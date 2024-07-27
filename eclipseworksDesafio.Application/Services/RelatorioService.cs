using eclipseworksDesafio.Application.Dtos.Relatorio;
using eclipseworksDesafio.Application.Interfaces;
using eclipseworksDesafio.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Application.Services
{

    public class RelatorioService : IRelatorioService
    {
        private readonly AppDbContext _context;

        public RelatorioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RelatorioDesempenhoDto> GerarRelatorioDesempenho()
        {
            var dataLimite = DateTime.Now.AddDays(-30);

            var relatorio = await _context.Tarefas
                .Where(t => t.DataConclusao >= dataLimite && t.Status == 3)
                .GroupBy(t => t.Projeto.UsuarioId)
                .Select(g => new
                {
                    UsuarioId = g.Key,
                    TarefasConcluidas = g.Count()
                })
                .ToListAsync();

            
            var totalUsuarios = relatorio.Count;
            var totalTarefas = relatorio.Sum(x => x.TarefasConcluidas);

            var mediaTarefasConcluidas = totalUsuarios > 0 ? (double)totalTarefas / totalUsuarios : 0;

            var resultado = new RelatorioDesempenhoDto
            {
                MediaTarefasConcluidas = mediaTarefasConcluidas,
                dataSolicitacao = DateTime.Now,
                responsalvel= relatorio.Select(c=>c.UsuarioId).FirstOrDefault().ToString(),
            };

            return resultado;
        }
    }
}
