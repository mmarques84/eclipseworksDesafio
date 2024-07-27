
using System.ComponentModel.DataAnnotations.Schema;

namespace eclipseworksDesafio.Core.Entities
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        public List<Tarefa>? Tarefas { get; set; }
        public bool Ativo {  get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime? DtExclusao { get; set; }
        public string? Observacao { get; set; }
    }
}
