using MediatR;

namespace BikeService.Contracts.Bike.Queries;

public record GetBikeByIdQuery(Guid BikeId)
  : IRequest<FluentResults.Result<BikeDto>>;
