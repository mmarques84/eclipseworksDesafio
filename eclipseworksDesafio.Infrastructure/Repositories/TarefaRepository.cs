using eclipseworksDesafio.Core.Entities;
using eclipseworksDesafio.Core.Enum;
using eclipseworksDesafio.Core.Interfaces;
using eclipseworksDesafio.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace eclipseworksDesafio.Infrastructure.Repositories
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        private readonly AppDbContext _context;
        public TarefaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tarefa> AtualizarTarefa(int tarefaId, Tarefa tarefaAlterarDto)
        {
            var tarefa = await _context.Tarefas.Where(c => c.Id == tarefaId).FirstOrDefaultAsync();
            if (tarefa == null)
            {
                throw new Exception("Tarefa não encontrada");
            }

            tarefa.Titulo = tarefaAlterarDto.Titulo;
            tarefa.Descricao = tarefaAlterarDto.Descricao;
            tarefa.Status = tarefaAlterarDto.Status;

            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task<Tarefa> CriarTarefa(Tarefa tarefaCreateDto)
        {
            if (tarefaCreateDto == null)
            {
                throw new ArgumentNullException(nameof(tarefaCreateDto));
            }

            if (string.IsNullOrEmpty(tarefaCreateDto.Titulo) || tarefaCreateDto.ProjetoId <= 0)
            {
                throw new ArgumentException("Título e ProjetoId são obrigatórios.");
            }
            var novaTarefa = new Tarefa
            {
                Titulo = tarefaCreateDto.Titulo,
                Descricao = tarefaCreateDto.Descricao,
                CriadoEm = DateTime.Now, // Você pode definir manualmente ou no construtor da Tarefa
                Status = tarefaCreateDto.Status,
                Prioridade = tarefaCreateDto.Prioridade,
                ProjetoId = tarefaCreateDto.ProjetoId
            };
            try
            {
                _context.Tarefas.Add(novaTarefa);
                await _context.SaveChangesAsync();

                return novaTarefa;
            }
            catch (Exception ex)
            {
             
                throw new InvalidOperationException("Erro ao criar a tarefa.", ex);
            }
        }

        public async Task<Tarefa> GetId(int tarefaId)
        {
            var tarefa = await _context.Tarefas.Include(P=>P.Projeto).Where(c => c.Id == tarefaId).FirstOrDefaultAsync();
            return tarefa;
        }

        public async Task<IEnumerable<Tarefa>> ListarTarefas()
        {
            var tarefa = await _context.Tarefas.ToListAsync();
            return tarefa;
        }

        public async Task<bool> RemoverTarefa(int tarefaId)
        {
            try
            {
                var tarefa = await _context.Tarefas.Where(c => c.Id == tarefaId).FirstOrDefaultAsync();

                bool tarefaEstaPendente = (Enums.StatusTarefa)tarefa.Status == Enums.StatusTarefa.Pendente;

                if (tarefaEstaPendente)
                {                    
                    return false; 
                }
                
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<IEnumerable<Tarefa>> GetTarefasDoProjeto(int projetoId)
        {
            return await _context.Tarefas.Include(p => p.Projeto)
                .Where(t => t.ProjetoId == projetoId)
                .ToListAsync();
        }
    }
}
