using API.DarkShame.Domain.Dto.Request;
using API.DarkShame.Domain.Dto.Request.Groups;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Entities.Contrys;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Groups;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace API.DarkShame.Controllers.Groups
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IServiceGroupInfo _serviceGroupInfo;

        public GroupController(IServiceGroupInfo serviceGroupInfo)
        {
            _serviceGroupInfo = serviceGroupInfo;
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
        [Route("/Groups")]
        [ProducesResponseType(typeof(GroupInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGroups()
        {
            var groups = await _serviceGroupInfo.GetGroup();

            if (groups.Count == 0)
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status404NotFound;
                detalhesDoProblema.Type = "NotFound";
                detalhesDoProblema.Title = "Registro não Encontrado";
                detalhesDoProblema.Detail = $"Não foram encontrados registros. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return NotFound(detalhesDoProblema);
            }

            return Ok(groups);
        }

        [HttpGet]
        [Route("/Groups/{idGroup}")]
        [ProducesResponseType(typeof(GroupInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGroupId(string idGroup)
        {
            var groupId = await _serviceGroupInfo.GroupId(idGroup);

            if (groupId is null)
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status404NotFound;
                detalhesDoProblema.Type = "NotFound";
                detalhesDoProblema.Title = "Registro não Encontrado";
                detalhesDoProblema.Detail = $"Não foram encontrados registros. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return NotFound(detalhesDoProblema);
            }

            return Ok(groupId);
        }


        [HttpPost]
        [Route("/Groups")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGroup([FromBody] GroupInfo groupInfo)
        {
            if (groupInfo != null)
            {
                var returnDto = await _serviceGroupInfo.CreateGroup(groupInfo);

                if (returnDto.ThereError == true)
                    return returnDto.ReturnResult(HttpContext.Request.Path);
                else
                {
                    return StatusCode((int)HttpStatusCode.Created, groupInfo);
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
        [Route("/Groups/{idGroup}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateGroup([FromBody] GroupInfoRequestDto groupInfoRequestDto)
        {
            var returnDto = await _serviceGroupInfo.UpdateGroup(groupInfoRequestDto);

            if (returnDto.ThereError == true)
                return returnDto.ReturnResult(HttpContext.Request.Path);
            else
            {
                return StatusCode((int)HttpStatusCode.OK, groupInfoRequestDto);
            }
        }

        [HttpDelete]
        [Route("/Groups/{idGroup}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteGroup(string idGroup)
        {
            var returnDto = await _serviceGroupInfo.DeleteGroup(idGroup);

            if (returnDto.ThereError == true)
                return returnDto.ReturnResult(HttpContext.Request.Path);
            else
            {
                return StatusCode((int)HttpStatusCode.OK, idGroup);
            }
        }
    }
}
