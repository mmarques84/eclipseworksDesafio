using eclipseworksDesafio.Core.Entities;

namespace eclipseworksDesafio.Core.Interfaces
{
    public interface IProjetoRepository
    {
        Task<IEnumerable<Projeto>> BuscarProjetosPorUsuarioId(int usuarioId);
        Task<Projeto> GetId(int projetoId);
        Task<IEnumerable<Projeto>> ListarProjetos();
        Task<IEnumerable<Projeto>> ListarProjetosAtivos();
        Task<int> ContarTarefasPorProjeto(int projetoId);
        Task<IEnumerable<Tarefa>> GetTarefasDoProjeto(int projetoId);
        Task<Projeto> BuscarProjetoComTarefas(int projetoId);
        Task<bool> RemoverProjeto(int projetoId);
        Task<Projeto> AlterarProjeto(int projetoId,Projeto projeto);
        Task<Projeto> CriarProjeto(Projeto projeto);
    }
}
