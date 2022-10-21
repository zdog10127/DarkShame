using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Entities.Store.Payment;
using API.DarkShame.Domain.Interfaces.Payment;
using API.DarkShame.Domain.Interfaces.Store.Game;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace API.DarkShame.Controllers.Store
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IServicePayments _servicePayments;

        public PaymentsController(IServicePayments servicePayments)
        {
            _servicePayments = servicePayments;
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
        [Route("/Payments")]
        [ProducesResponseType(typeof(Payments), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await _servicePayments.GetPayments();

            if (payments.Count == 0)
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status404NotFound;
                detalhesDoProblema.Type = "NotFound";
                detalhesDoProblema.Title = "Registro não Encontrado";
                detalhesDoProblema.Detail = $"Não foram encontrados registros. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return NotFound(detalhesDoProblema);
            }

            return Ok(payments);
        }

        [HttpGet]
        [Route("/Payments/{codePayment}")]
        [ProducesResponseType(typeof(Payments), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaymentsById(int codePayment)
        {
            var payments = await _servicePayments.GetPaymentsById(codePayment);

            if (payments is null)
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status404NotFound;
                detalhesDoProblema.Type = "NotFound";
                detalhesDoProblema.Title = "Registro não Encontrado";
                detalhesDoProblema.Detail = $"Não foram encontrados registros. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return NotFound(detalhesDoProblema);
            }

            return Ok(payments);
        }

        [HttpPost]
        [Route("/Payments")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePayments([FromBody] Payments payments)
        {
            if (payments != null)
            {
                var returnDto = await _servicePayments.CreatePayments(payments);

                if (returnDto.ThereError == true)
                    return returnDto.ReturnResult(HttpContext.Request.Path);
                else
                {
                    return StatusCode((int)HttpStatusCode.Created, payments);
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
