using MediatR;

namespace BikeService.Contracts.Bike.Commands;

public record RentBikeCommand(
  string Name,
  string SerialNumber,
  decimal Latitude,
  decimal Longitude
) : IRequest<FluentResults.Result<CreateBikeResult>>;

