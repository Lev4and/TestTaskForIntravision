using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestTaskForIntravision.Application.UseCases.Queries;
using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Infrastructure.Web.Http;

namespace TestTaskForIntravision.WebApi.Controllers
{
    [ApiController]
    [Route("api/coins/v{apiVersion:apiVersion}/")]
    public class CoinsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoinsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<Coin>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCoinsAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetCoinsQuery(), cancellationToken));
        }
    }
}
