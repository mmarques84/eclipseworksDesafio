using eclipseworksDesafio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Core.Interfaces
{
    public interface IComentarioRepository
    {
        Task<IEnumerable<Comentario>> GetAllComentariosAsync();
        Task<Comentario> GetComentarioByIdAsync(int id);
        Task<Comentario> AdicionarComentarioAsync(Comentario comentario);
        Task<Comentario> AlterarComentarioAsync(Comentario comentario);
        Task<bool> DeletarComentarioAsync(int id);
    }
}
