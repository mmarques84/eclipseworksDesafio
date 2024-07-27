using eclipseworksDesafio.Application.Dtos.Tarefa;
using eclipseworksDesafio.Application.Dtos.Usuario;
using System.ComponentModel.DataAnnotations.Schema;

namespace eclipseworksDesafio.Application.Dtos.Projeto
{
    public class ProjetoGetDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public UsuarioGetDTO Usuario { get; set; }
        public List<TarefaGetDto>? Tarefas { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime? DtExclusao { get; set; }
        public string? Observacao { get; set; }
    }
}
