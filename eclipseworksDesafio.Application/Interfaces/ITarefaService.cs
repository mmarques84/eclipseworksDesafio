using eclipseworksDesafio.Application.Dtos.Projeto;
using eclipseworksDesafio.Application.Dtos.Tarefa;
using eclipseworksDesafio.Core.Entities;



namespace eclipseworksDesafio.Application.Services
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefaGetDto>> ListarTarefas();
        Task<IEnumerable<TarefaGetDto>> GetTarefasDoProjeto(int projetoId);
        Task<TarefaCreateDto> CriarTarefa(TarefaCreateDto tarefaCreateDto);
        Task<TarefaAlterarDto> AtualizarTarefa(int tarefaId, TarefaAlterarDto tarefaAlterarDto);
        Task<bool> RemoverTarefa(int tarefaId);
        Task<TarefaGetDto> GetId(int tarefaId);
    }
}
