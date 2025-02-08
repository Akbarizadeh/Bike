using MediatR;

namespace BikeService.Contracts.Bike.Commands;

public record UpdateBikeCommand(
  Guid BikeId,
  string Name,
  string SerialNumber
) : IRequest<FluentResults.Result>;
