
using System.ComponentModel.DataAnnotations.Schema;

namespace eclipseworksDesafio.Core.Entities
{
    
    public class HistoricoTarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }        
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        public int TarefaId { get; set; }
        [ForeignKey("TarefaId")]
        public Tarefa Tarefa { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
