using eclipseworksDesafio.Application.Dtos.Tarefa;
using eclipseworksDesafio.Application.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Application.Dtos.Projeto
{
    public class ProjetoAlterarDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }       
        public bool Ativo { get; set; }
        public string? Observacao { get; set; }
    }
}
