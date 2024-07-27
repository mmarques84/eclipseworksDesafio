using eclipseworksDesafio.Application.Dtos.Enum;
using eclipseworksDesafio.Application.Dtos.Projeto;
using eclipseworksDesafio.Application.Dtos.Tarefa;
using eclipseworksDesafio.Application.Dtos.Usuario;
using eclipseworksDesafio.Application.Services;
using eclipseworksDesafio.ApplicationApplication.Dtos.Projeto;
using eclipseworksDesafio.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eclipseworksDesafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {

        private readonly ProjetoService _projetoNegocio;

        public ProjetosController(ProjetoService projetoNegocio)
        {
            _projetoNegocio = projetoNegocio;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> Get()
        {
            var tarefas = await _projetoNegocio.ListarProjetos();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> GetById(int id)
        {
            var Projeto = await _projetoNegocio.GetId(id);
            if (Projeto == null)
            {
                return NotFound();
            }
            return Ok(Projeto);
        }
        [HttpGet("{usuarioId}/ProjetosUsuarios")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ProjetosUsuarios(int usuarioId)
        {
            var Projetos = await _projetoNegocio.BuscarProjetosPorUsuarioId(usuarioId);
            if (Projetos == null)
            {
                return NotFound();
            }
            return Ok(Projetos);
        }
        [HttpGet("{projetoId}/TarefasDoProjeto")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefasDoProjeto(int projetoId)
        {
            var tarefas = await _projetoNegocio.GetTarefasDoProjeto(projetoId);
            if (tarefas == null)
            {
                return NotFound();
            }
            return Ok(tarefas);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProjetoCreateDto projetoCreateDto)
        {
            //var usuario = await _usuarioRepository.GetByIdAsync(projetoCreateDto.UsuarioId);
            //if (usuario == null)
            //{
            //    throw new Exception("Usuário não encontrado.");
            //}
            try
            {
                var projetoCriado = await _projetoNegocio.CriarProjeto(projetoCreateDto);
                return Ok(projetoCriado);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProjetoAlterarDto projeto)
        {
            if (id != projeto.Id)
            {
                return BadRequest();
            }
            try
            {
                var projetoAlterado = await _projetoNegocio.AlterarProjeto(id, projeto);
                return Ok(projetoAlterado);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _projetoNegocio.RemoverProjeto(id);
                if (result)
                {
                    return Ok(new { message = "Projeto excluído com sucesso." });
                }
                else
                {
                    var erroResponse = new
                    {
                        mensagem = "Para excluir o projeto é necessário concluir as tarefas ou remover as tarefas primeiro."
                    };
                    return BadRequest(erroResponse);
                }
                //Caso o usuário tente remover um projeto com tarefas pendentes, a API deve retornar um erro e sugerir a conclusão ou remoção das tarefas primeiro.


            }
            catch (Exception)
            {

                var erroResponse = new
                {
                    mensagem = "Ocorreu um erro ao tentar remover o projeto."
                };
                return StatusCode(500, erroResponse);
            }

        }

    }
}
