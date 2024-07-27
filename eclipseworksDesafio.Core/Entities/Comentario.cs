namespace eclipseworksDesafio.Core.Entities
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime DtCadastro { get; set; } = DateTime.Now;    
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}
