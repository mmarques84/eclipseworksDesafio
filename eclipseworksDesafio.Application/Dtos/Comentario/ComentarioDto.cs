using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Application.Dtos.Comentario
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public int TarefaId { get; set; }
    }
}
