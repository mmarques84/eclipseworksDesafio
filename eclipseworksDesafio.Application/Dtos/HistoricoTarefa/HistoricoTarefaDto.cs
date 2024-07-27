using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Application.Dtos.HistoricoTarefa
{
    public class HistoricoTarefaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public int TarefaId { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
