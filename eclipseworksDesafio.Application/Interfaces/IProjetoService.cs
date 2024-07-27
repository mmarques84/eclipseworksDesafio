using eclipseworksDesafio.Application.Dtos.Projeto;
using eclipseworksDesafio.Application.Dtos.Tarefa;
using eclipseworksDesafio.ApplicationApplication.Dtos.Projeto;
using eclipseworksDesafio.Core.Entities;

namespace eclipseworksDesafio.Application.Interfaces
{
    public interface IProjetoService
    {
        
        Task<IEnumerable<ProjetoGetDto>> BuscarProjetosPorUsuarioId(int usuarioId);
        Task<IEnumerable<ProjetoGetDto>> ListarProjetosAtivos();
        Task<int> ContarTarefasPorProjeto(int projetoId);
        Task<IEnumerable<TarefaGetDto>> GetTarefasDoProjeto(int projetoId);
        Task<ProjetoGetDto> BuscarProjetoComTarefas(int projetoId);
        Task<ProjetoGetDto> GetId(int projetoId);
        Task<IEnumerable<ProjetoGetDto>> ListarProjetos();
        Task<bool> RemoverProjeto(int projetoId);
        Task<ProjetoGetDto> AlterarProjeto(int projetoId, ProjetoAlterarDto projeto);
        Task<ProjetoGetDto> CriarProjeto(ProjetoCreateDto projeto);

    }
}
