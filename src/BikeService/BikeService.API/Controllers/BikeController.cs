using AutoMapper;
using BikeService.Contracts.Bike.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/bikes")]
public class BikeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BikeController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBike([FromBody] CreateBikeRequest request)
    {
        var command = _mapper.Map<CreateBikeCommand>(request);
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(result.Errors);
    }
}
