using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TestTaskForIntravision.Application.UseCases.Commands;
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

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCoinAsync([Required][FromBody] Coin coin,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new UpdateCoinCommand(coin), cancellationToken));
        }
    }
}
