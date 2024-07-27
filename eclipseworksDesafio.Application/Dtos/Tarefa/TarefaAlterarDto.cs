using static eclipseworksDesafio.Application.Dtos.Enum.Enums;

namespace eclipseworksDesafio.Application.Dtos.Tarefa
{
    public class TarefaAlterarDto
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public int Status { get; set; }
    }
}
