using eclipseworksDesafio.Core.Entities;
using eclipseworksDesafio.Core.Interfaces;
using eclipseworksDesafio.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Infrastructure.Repositories
{
    public class HistoricoTarefasRepository : Repository<HistoricoTarefa>, IHistoricoTarefasRepository
    {
        private readonly AppDbContext _context;
        public HistoricoTarefasRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AdicionarHistorico(HistoricoTarefa historico)
        {
            _context.HistoricoTarefas.Add(historico);
            await _context.SaveChangesAsync();
        }
    }
}
