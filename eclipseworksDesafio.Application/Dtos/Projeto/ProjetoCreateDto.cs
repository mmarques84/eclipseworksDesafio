
using eclipseworksDesafio.Application.Dtos.Tarefa;

namespace eclipseworksDesafio.ApplicationApplication.Dtos.Projeto
{
    public class ProjetoCreateDto
    {
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public bool Ativo { get; set; }
        public string? Observacao { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public List<TarefaCreateDto>? Tarefas { get; set; }
    }
}
