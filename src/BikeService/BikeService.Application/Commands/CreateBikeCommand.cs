
using BikeService.Contracts.Bike.Commands;
using BikeService.Domain.Entities;
using BikeService.Domain.ValueObjects;
using MediatR;

namespace BikeService.Application.Commands
{

    public class CreateBikeCommandHandler : IRequestHandler<CreateBikeCommand, FluentResults.Result<CreateBikeResult>>
    {
        public async Task<FluentResults.Result<CreateBikeResult>> Handle(CreateBikeCommand request, CancellationToken cancellationToken)
        {
            var bike = new Bike(request.SerialNumber, new BikeLocation(request.Latitude, request.Longitude));
            return await Task.FromResult(new CreateBikeResult(bike.Id, bike.SerialNumber ));
        }
    }
}
