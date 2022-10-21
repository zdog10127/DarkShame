using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Interfaces.Store.Game;
using API.DarkShame.Services.Store.Game;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace API.DarkShame.Controllers.Store.Game
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IServiceResources _serviceResources;

        public ResourcesController(IServiceResources serviceResources)
        {
            _serviceResources = serviceResources;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HealthCheck()
        {
            StringBuilder informacoes = new StringBuilder();
            informacoes.AppendLine($"DarkShame = API.DarkShame");
            informacoes.AppendLine($"Situação = Saudável");

            return Ok(informacoes.ToString());
        }

        [HttpGet]
        [Route("/Resources/{idGame}")]
        [ProducesResponseType(typeof(Resources), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetResourcesByIdGame(string idGame)
        {
            var resources = await _serviceResources.GetResourcesByIdGame(idGame);

            if (resources is null)
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status404NotFound;
                detalhesDoProblema.Type = "NotFound";
                detalhesDoProblema.Title = "Registro não Encontrado";
                detalhesDoProblema.Detail = $"Não foram encontrados registros. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return NotFound(detalhesDoProblema);
            }

            return Ok(resources);
        }

        [HttpPut]
        [Route("/Resources/{idGame}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateResources([FromBody] Resources resources, string idGame)
        {
            var returnDto = await _serviceResources.UpdateResources(resources, idGame);

            if (returnDto.ThereError == true)
                return returnDto.ReturnResult(HttpContext.Request.Path);
            else
            {
                return StatusCode((int)HttpStatusCode.OK, resources);
            }
        }
    }
}
