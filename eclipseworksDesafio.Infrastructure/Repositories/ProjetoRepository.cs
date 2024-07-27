using eclipseworksDesafio.Core.Entities;
using eclipseworksDesafio.Core.Enum;
using eclipseworksDesafio.Core.Interfaces;
using eclipseworksDesafio.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace eclipseworksDesafio.Infrastructure.Repositories
{
    public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
    {
        private readonly AppDbContext _context;
        public ProjetoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Projeto> BuscarProjetoComTarefas(int projetoId)
        {
            return await _context.Projetos.Include(t => t.Tarefas).Include(u => u.Usuario)
               .Where(p => p.Id == projetoId)
               .FirstAsync();
        }

        public async Task<IEnumerable<Projeto>> BuscarProjetosPorUsuarioId(int usuarioId)
        {
            return await _context.Projetos
                .Include(t => t.Tarefas)
                 .Include(u => u.Usuario)
               .Where(p => p.UsuarioId == usuarioId)
               .ToListAsync();
        }

        public async Task<int> ContarTarefasPorProjeto(int projetoId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tarefa>> GetTarefasDoProjeto(int projetoId)
        {
            return await _context.Tarefas.Include(p => p.Projeto)
                .Where(t => t.ProjetoId == projetoId)
                .ToListAsync();
        }

        public async Task<Projeto> GetId(int projetoId)
        {
            return await _context.Projetos
            .Include(p => p.Tarefas)
            .Include(u => u.Usuario)
            .Where(p => p.Id == projetoId)
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Projeto>> ListarProjetosAtivos()
        {
            return await _context.Projetos
                .Include(t => t.Tarefas)
                 .Include(u => u.Usuario)
             .Where(p => p.Ativo)
             .ToListAsync();
        }

        public async Task<bool> RemoverProjeto(int projetoId)
        {
            try
            {
                var projeto = _context.Projetos
                    .Where(p => p.Id == projetoId)
                    .Select(p => new
                    {
                        Projeto = p,
                        TarefasPendentes = p.Tarefas.Any(t => (Enums.StatusTarefa)t.Status == Enums.StatusTarefa.Pendente)
                    })
                .FirstOrDefault();

                // Se o projeto não existe ou tem tarefas pendentes, não pode ser removido
                if (projeto == null || projeto.TarefasPendentes)
                {
                    return false;
                }
                _context.Projetos.Remove(projeto.Projeto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<Projeto>> ListarProjetos()
        {
            return await _context.Projetos
                  .Include(p => p.Tarefas)
                  .Include(u => u.Usuario)

          .ToListAsync();
        }

        public async Task<Projeto> AlterarProjeto(int projetoId, Projeto projeto)
        {
            var projetoDto =  await _context.Projetos.Include(t => t.Tarefas).Include(u => u.Usuario)
              .Where(p => p.Id == projetoId)
              .FirstAsync();

            projetoDto.Ativo = projeto.Ativo;
            projetoDto.Descricao = projeto.Descricao;
            projetoDto.UsuarioId = projeto.UsuarioId;
            projeto.Observacao = projeto.Observacao;
            _context.Update(projetoDto);
            await _context.SaveChangesAsync();

            return projetoDto;

        }

        public async Task<Projeto> CriarProjeto(Projeto projeto)
        {
         
            _context.Projetos.Add(projeto);

            await _context.SaveChangesAsync();

            return await _context.Projetos
                .Include(p => p.Usuario)
                .Include(p => p.Tarefas)
                .SingleOrDefaultAsync(p => p.Id == projeto.Id);
        }
    }
}
