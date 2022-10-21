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
    public class LanguageController : ControllerBase
    {
        private readonly IServiceLanguage _serviceLanguage;

        public LanguageController(IServiceLanguage serviceLanguage)
        {
            _serviceLanguage = serviceLanguage;
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
        [Route("/Language/{idGame}")]
        [ProducesResponseType(typeof(Languages), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLanguagesByIdGame(string idGame)
        {
            var languages = await _serviceLanguage.GetLanguagesByIdGame(idGame);

            if (languages.Count == 0)
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status404NotFound;
                detalhesDoProblema.Type = "NotFound";
                detalhesDoProblema.Title = "Registro não Encontrado";
                detalhesDoProblema.Detail = $"Não foram encontrados registros. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return NotFound(detalhesDoProblema);
            }

            return Ok(languages);
        }

        [HttpPost]
        [Route("/Language")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLanguages([FromBody] Languages languages)
        {
            if (languages != null)
            {
                var returnDto = await _serviceLanguage.CreateLanguages(languages);

                if (returnDto.ThereError == true)
                    return returnDto.ReturnResult(HttpContext.Request.Path);
                else
                {
                    return StatusCode((int)HttpStatusCode.Created, languages);
                }
            }
            else
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status400BadRequest;
                detalhesDoProblema.Type = "BadRequest";
                detalhesDoProblema.Title = "Registro não pode ser nulo";
                detalhesDoProblema.Detail = $"Dados não podem ser vazio ou nulo. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return BadRequest(detalhesDoProblema);
            }
        }
    }
}
