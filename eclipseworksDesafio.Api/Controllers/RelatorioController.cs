using eclipseworksDesafio.Application.Dtos.Relatorio;
using eclipseworksDesafio.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eclipseworksDesafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatorioController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet("RelatorioGerencial")]
        public async Task<ActionResult<RelatorioDesempenhoDto>> ObterRelatorioDesempenho()
        {
            try
            {
                var relatorio = await _relatorioService.GerarRelatorioDesempenho();
                return Ok(relatorio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
