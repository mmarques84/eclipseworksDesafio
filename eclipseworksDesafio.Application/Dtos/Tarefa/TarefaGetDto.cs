using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eclipseworksDesafio.Application.Dtos.Enum.Enums;

namespace eclipseworksDesafio.Application.Dtos.Tarefa
{   
    public class TarefaGetDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
        public StatusTarefa Status { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
        public int ProjetoId { get; set; }
    }
}
