using eclipseworksDesafio.Application.Dtos.Comentario;
using eclipseworksDesafio.Application.Interfaces;
using eclipseworksDesafio.Core.Entities;
using eclipseworksDesafio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Application.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioService(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

     

        public async Task<IEnumerable<ComentarioDto>> GetAllComentariosAsync()
        {
            var comentarios = await _comentarioRepository.GetAllComentariosAsync();
            return comentarios.Select(c => new ComentarioDto
            {
                Id = c.Id,
                Texto = c.Texto,               
                TarefaId = c.TarefaId
            });
        }

        public async Task<ComentarioDto> GetComentarioByIdAsync(int id)
        {
            var comentario = await _comentarioRepository.GetComentarioByIdAsync(id);
            if (comentario == null) return null;

            return new ComentarioDto
            {
                Id = comentario.Id,
                Texto = comentario.Texto,
                TarefaId = comentario.TarefaId
            };
        }

        public async Task<ComentarioDto> AdicionarComentarioAsync(Comentario comentarioDto)
        {
            var comentario = new Comentario
            {
                Texto = comentarioDto.Texto,
                TarefaId = comentarioDto.TarefaId
            };

            var createdComentario = await _comentarioRepository.AdicionarComentarioAsync(comentario);
            return new ComentarioDto
            {
                Id = createdComentario.Id,
                Texto = createdComentario.Texto,
                TarefaId = createdComentario.TarefaId
            };
        }

        public async Task<ComentarioDto> AlterarComentarioAsync(Comentario comentarioDto)
        {
            var comentario = await _comentarioRepository.GetComentarioByIdAsync(comentarioDto.Id);
            if (comentario == null) return null;

            comentario.Texto = comentarioDto.Texto;
            comentario.TarefaId = comentarioDto.TarefaId;

            var updatedComentario = await _comentarioRepository.AlterarComentarioAsync(comentario);
            return new ComentarioDto
            {
                Id = updatedComentario.Id,
                Texto = updatedComentario.Texto,
                TarefaId = updatedComentario.TarefaId
            };
        }

        public async Task<bool> DeletarComentarioAsync(int id)
        {
            return await _comentarioRepository.DeletarComentarioAsync(id);
        }
    }
}
