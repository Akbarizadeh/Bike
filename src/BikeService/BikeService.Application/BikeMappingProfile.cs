using AutoMapper;
using BikeService.Contracts.Bike.Commands;

public class BikeMappingProfile : Profile
{
    public BikeMappingProfile()
    {
        CreateMap<CreateBikeRequest, CreateBikeCommand>();
    }
}
