using Microsoft.AspNetCore.Mvc;

namespace eclipseworksDesafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //private readonly IService<Usuario> _usuarioService;
        //public UsuariosController(IService<Usuario> usuarioService)
        //{
        //    _usuarioService= usuarioService;
        //}
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        //{
        //    var usuario = _usuarioService.GetAll();
        //    return Ok(usuario);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Usuario>> GetById(int id)
        //{
        //    var usuario = _usuarioService.GetById(id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(usuario);
        //}

        //[HttpPost]
        //public async Task<ActionResult> Post([FromBody] UsuarioCreateDTO usuarioDto)
        //{
        //    var usuario = new Usuario
        //    {
        //        Nome = usuarioDto.Nome,
        //        DataNasc = usuarioDto.DataNasc,
        //        Ativo = usuarioDto.Ativo,

        //    };
        //    await _usuarioService.Insert(usuario);
        //    return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put(int id, [FromBody] UsuarioCreateDTO usuarioDto)
        //{
        //    var usuario = new Usuario
        //    {
        //        Nome = usuarioDto.Nome,
        //        DataNasc = usuarioDto.DataNasc,
        //        Ativo = usuarioDto.Ativo,
                
        //    };
        //    if (id != usuario.Id)
        //    {
        //        return BadRequest();
        //    }
        //    _usuarioService.Update(usuario);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        _usuarioService.Delete(id);
        //        return NoContent();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
    }
}
