using API.DarkShame.Domain.Dto.Request;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Interfaces.Groups;
using API.DarkShame.Domain.Interfaces.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace API.DarkShame.Controllers.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerInfoController : ControllerBase
    {
        private readonly IServiceServerInfo _serviceServerInfo;

        public ServerInfoController(IServiceServerInfo serviceServerInfo)
        {
            _serviceServerInfo = serviceServerInfo;
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
        [Route("/ServerStatus")]
        [ProducesResponseType(typeof (ServerInfo),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ServerStatus()
        {
            var server = await _serviceServerInfo.ServerStatus();

            if (server is null)
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status404NotFound;
                detalhesDoProblema.Type = "NotFound";
                detalhesDoProblema.Title = "Registro não Encontrado";
                detalhesDoProblema.Detail = $"Não foram encontrados registros. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return NotFound(detalhesDoProblema);
            }

            return Ok(server);
        }

        [HttpPost]
        [Route("/ServerStatus")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateStatusServer([FromBody] ServerInfo serverInfo)
        {
            if (serverInfo != null)
            {
                var returnDto = await _serviceServerInfo.CreateStatusServer(serverInfo);

                if (returnDto.ThereError == true)
                    return returnDto.ReturnResult(HttpContext.Request.Path);
                else
                {
                    return StatusCode((int)HttpStatusCode.Created, serverInfo);
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

        [HttpPut]
        [Route("/Server/{idServer}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStatusServer([FromBody] ServerInfo serverInfo)
        {
            var returnDto = await _serviceServerInfo.UpdateStatusServer(serverInfo);

            if (returnDto.ThereError == true)
                return returnDto.ReturnResult(HttpContext.Request.Path);
            else
            {
                return StatusCode((int)HttpStatusCode.OK, serverInfo);
            }

        }
    }
}
