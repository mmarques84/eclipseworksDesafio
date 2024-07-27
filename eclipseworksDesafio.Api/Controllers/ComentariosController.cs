using eclipseworksDesafio.Application.Dtos.Comentario;
using eclipseworksDesafio.Application.Interfaces;
using eclipseworksDesafio.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eclipseworksDesafio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentarioService _comentarioService;

        public ComentariosController(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var comentarios = await _comentarioService.GetAllComentariosAsync();
            return Ok(comentarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var comentario = await _comentarioService.GetComentarioByIdAsync(id);
            if (comentario == null) return NotFound();
            return Ok(comentario);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ComentarioDto comentarioDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var comentario = new Comentario
            {
                Texto = comentarioDto.Texto,
                TarefaId = comentarioDto.TarefaId,
                
            };
            var createdComentario = await _comentarioService.AdicionarComentarioAsync(comentario);
            return CreatedAtAction(nameof(Get), new { id = createdComentario.Id }, createdComentario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ComentarioDto comentarioDto)
        {
            if (id != comentarioDto.Id) return BadRequest();
            var Comentario = new Comentario
            {

            };
            var updatedComentario = await _comentarioService.AlterarComentarioAsync(Comentario);
            if (updatedComentario == null) return NotFound();

            return Ok(updatedComentario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _comentarioService.DeletarComentarioAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }   
}
