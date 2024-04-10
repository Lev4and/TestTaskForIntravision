using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TestTaskForIntravision.Application.DTOs;
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
        public async Task<IActionResult> AddBeverageAsync([Required][FromBody] Beverage beverage,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new AddBeverageCommand(beverage), cancellationToken));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<Beverage>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBeveragesAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetBeveragesQuery(), cancellationToken));
        }

        [HttpPost]
        [Route("buy")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyDictionary<decimal, uint>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> BuyBeveragesAsync([Required][FromBody] BuyBeveragesDto dto, 
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new BuyBeveragesCommand(dto.DepositedCoins, dto.SelectedBeverages), 
                cancellationToken));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBeverageAsync([Required][FromBody] Beverage beverage,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new UpdateBeverageCommand(beverage), cancellationToken));
        }

        [HttpDelete]
        [Route("{id:guid:required}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBeverageAsync([Required][FromRoute(Name = "id")] Guid id,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new DeleteBeverageCommand(id), cancellationToken));
        }
    }
}
