using MediatR;

namespace BikeService.Contracts.Bike.Commands;

public record DeleteBikeCommand(Guid BikeId)
 : IRequest<FluentResults.Result>;
