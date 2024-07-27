using eclipseworksDesafio.Application.Dtos.Tarefa;
using eclipseworksDesafio.Application.Services;
using eclipseworksDesafio.Core.Entities;
using eclipseworksDesafio.Core.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace eclipseworksDesafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly TarefaService _tarefaNegocio;
        public TarefasController( TarefaService tarefaNegocio)
        {            
            _tarefaNegocio = tarefaNegocio;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> Get()
        {

            var tarefa = await _tarefaNegocio.ListarTarefas();
            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetById(int id)
        {
            var tarefa =await _tarefaNegocio.GetId(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TarefaCreateDto tarefaDTO)
        {
            var tarefasExistentes = await _tarefaNegocio.GetTarefasDoProjeto(tarefaDTO.ProjetoId);
            if (tarefasExistentes.Count() >= 20)
            {
                throw new Exception("Não é permitido adicionar mais de 20 tarefas a um projeto.");
            }
            var novaTarefa = new Tarefa
            {
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                CriadoEm = DateTime.Now, // Você pode definir manualmente ou no construtor da Tarefa
                Status =tarefaDTO.Status,
                Prioridade = tarefaDTO.Prioridade,
                ProjetoId = tarefaDTO.ProjetoId
            };
            //await _tarefaService.Insert(novaTarefa);
            return CreatedAtAction(nameof(GetById), new { id = novaTarefa.Id }, novaTarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarTarefa(int id, [FromBody] TarefaAlterarDto tarefa)
        {
            try
            {
                var result =await _tarefaNegocio.AtualizarTarefa(id, tarefa);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _tarefaNegocio.RemoverTarefa(id);

                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
