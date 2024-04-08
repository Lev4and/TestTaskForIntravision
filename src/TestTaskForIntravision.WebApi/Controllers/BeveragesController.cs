using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestTaskForIntravision.Application.UseCases.Commands;
using TestTaskForIntravision.Application.UseCases.Queries;
using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Infrastructure.Web.Http;

namespace TestTaskForIntravision.WebApi.Controllers
{
    [ApiController]
    [Route("api/beverages/v{apiVersion:apiVersion}/")]
    public class BeveragesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BeveragesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddBeverageAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new AddBeverageCommand(), cancellationToken));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<Beverage>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBeveragesAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetBeveragesQuery(), cancellationToken));
        }

        [HttpPost]
        [Route("buy")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> BuyBeveragesAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new BuyBeveragesCommand(), cancellationToken));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBeverageAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new UpdateBeverageCommand(), cancellationToken));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBeverageAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new DeleteBeverageCommand(), cancellationToken));
        }
    }
}
