

namespace eclipseworksDesafio.Application.Dtos.Tarefa
{
    public class TarefaCreateDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public int Status { get; set; }
        public int Prioridade { get; set; }
        public int ProjetoId { get; set; }
    }
}
