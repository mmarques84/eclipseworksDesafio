using eclipseworksDesafio.Application.Dtos.Comentario;
using eclipseworksDesafio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Application.Interfaces
{
    public interface IComentarioService
    {
        Task<IEnumerable<ComentarioDto>> GetAllComentariosAsync();
        Task<ComentarioDto> GetComentarioByIdAsync(int id);
        Task<ComentarioDto> AdicionarComentarioAsync(Comentario comentario);
        Task<ComentarioDto> AlterarComentarioAsync(Comentario comentario);
        Task<bool> DeletarComentarioAsync(int id);
    }
}
