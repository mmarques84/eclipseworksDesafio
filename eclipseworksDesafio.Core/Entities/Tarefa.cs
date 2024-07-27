using System.ComponentModel.DataAnnotations.Schema;

namespace eclipseworksDesafio.Core.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public int Status { get; set; }
        public int Prioridade { get; set; }
        public int ProjetoId { get; set; }
        [ForeignKey("ProjetoId")]
        public  Projeto? Projeto { get; set; }
        public List<HistoricoTarefa>? Historico { get; set; }
        public List<Comentario>? Comentarios { get; set; }
        public DateTime? DataConclusao {  get; set; }
    }
}
