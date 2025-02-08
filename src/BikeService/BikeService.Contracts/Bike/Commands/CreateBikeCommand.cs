using MediatR;

namespace BikeService.Contracts.Bike.Commands;
public record CreateBikeCommand(
  string Name,
  string SerialNumber,
  decimal Latitude,
  decimal Longitude
) : IRequest<FluentResults.Result<CreateBikeResult>>;

