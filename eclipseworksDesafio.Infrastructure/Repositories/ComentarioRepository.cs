using eclipseworksDesafio.Core.Entities;
using eclipseworksDesafio.Core.Interfaces;
using eclipseworksDesafio.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Infrastructure.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly AppDbContext _context;

        public ComentarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comentario>> GetAllComentariosAsync()
        {
            return await _context.Comentarios.ToListAsync();
        }

        public async Task<Comentario> GetComentarioByIdAsync(int id)
        {
            return await _context.Comentarios.FindAsync(id);
        }


        public async Task<Comentario> AdicionarComentarioAsync(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();
            return comentario;
        }

        public async Task<Comentario> AlterarComentarioAsync(Comentario comentario)
        {
            _context.Comentarios.Update(comentario);
            await _context.SaveChangesAsync();
            return comentario;
        }

        public async Task<bool> DeletarComentarioAsync(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null) return false;

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
