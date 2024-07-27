using eclipseworksDesafio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Core.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetTarefasDoProjeto(int projetoId);
        Task<IEnumerable<Tarefa>> ListarTarefas();
        Task<Tarefa> GetId(int tarefaId);
        Task<Tarefa> CriarTarefa(Tarefa tarefaCreateDto);
        Task<Tarefa> AtualizarTarefa(int tarefaId, Tarefa tarefaAlterarDto);
        Task<bool> RemoverTarefa(int tarefaId);
    }
}
