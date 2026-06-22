using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperGiros.Transfer.Application.UseCases.Features.Transaction.Querys.GetAllTransaction;
using SuperGiros.Transfer.Application.UseCases.Features.Transaction.Commands.CreateTransaction;

namespace SuperGiros.Transfer.Services.gRPC.Commons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Exige el token JWT que React ya está enviando
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // 1. Obtener historial (GET /api/Transaction)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // El mediator llama al handler, que ya devuelve la lista (IEnumerable)
                var response = await _mediator.Send(new GetAllTransactionQuery());

                // Devolvemos la lista directamente. 
                // Si el frontend espera un objeto, puedes envolverlo en un objeto simple:
                return Ok(new { data = response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        // 2. Registrar un nuevo giro (POST /api/Transaction)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}