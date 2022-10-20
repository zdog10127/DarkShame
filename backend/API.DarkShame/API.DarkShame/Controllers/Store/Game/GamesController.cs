using API.DarkShame.Domain.Dto.Request.Groups;
using API.DarkShame.Domain.Dto.Request.Store.Game;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Interfaces.Store.Game;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace API.DarkShame.Controllers.Store.Game
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IServiceGames _serviceGames;

        public GamesController(IServiceGames serviceGames)
        {
            _serviceGames = serviceGames;
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
        [Route("/Games")]
        [ProducesResponseType(typeof(Games), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGames()
        {
            var games = await _serviceGames.GetGames();

            if (games.Count == 0)
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status404NotFound;
                detalhesDoProblema.Type = "NotFound";
                detalhesDoProblema.Title = "Registro não Encontrado";
                detalhesDoProblema.Detail = $"Não foram encontrados registros. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return NotFound(detalhesDoProblema);
            }

            return Ok(games);
        }

        [HttpGet]
        [Route("/Games/{idGame}")]
        [ProducesResponseType(typeof(Games), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGamesById(string idGame)
        {
            var gameId = await _serviceGames.GetGamesById(idGame);

            if (gameId is null)
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status404NotFound;
                detalhesDoProblema.Type = "NotFound";
                detalhesDoProblema.Title = "Registro não Encontrado";
                detalhesDoProblema.Detail = $"Não foram encontrados registros. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return NotFound(detalhesDoProblema);
            }

            return Ok(gameId);
        }


        [HttpPost]
        [Route("/Games")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGame([FromBody] GamesRequestDto gamesRequestDto)
        {
            if (gamesRequestDto != null)
            {
                var returnDto = await _serviceGames.CreateGame(gamesRequestDto);

                if (returnDto.ThereError == true)
                    return returnDto.ReturnResult(HttpContext.Request.Path);
                else
                {
                    return StatusCode((int)HttpStatusCode.Created, gamesRequestDto);
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
        [Route("/Games/{idGame}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateGame([FromBody] Games games)
        {
            var returnDto = await _serviceGames.UpdateGame(games);

            if (returnDto.ThereError == true)
                return returnDto.ReturnResult(HttpContext.Request.Path);
            else
            {
                return StatusCode((int)HttpStatusCode.OK, games);
            }
        }

        [HttpDelete]
        [Route("/Games/{idGame}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteGroup(string idGame)
        {
            var returnDto = await _serviceGames.DeleteGame(idGame);

            if (returnDto.ThereError == true)
                return returnDto.ReturnResult(HttpContext.Request.Path);
            else
            {
                return StatusCode((int)HttpStatusCode.OK, idGame);
            }
        }
    }
}
