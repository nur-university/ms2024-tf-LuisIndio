using Application.UseCase.AnalysisRequest.Command.CreateAnalysisRequest;
using Application.UseCase.Nutritionists.Command.CreateNutritionist.Application.Nutritionists.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAnalysisRequest([FromBody] CreateAnalysisRequestCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return Ok(id);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
}
    }
