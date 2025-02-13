using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAssetBookingCancellation.Commands.CreateCoreAssetBookingCancellationCommand;
using Bussiness.Features.CoreAssetBookingCancellation.Commands.DeleteCoreAssetBookingCancellationCommand;
using Bussiness.Features.CoreAssetBookingCancellation.Commands.UpdateCoreAssetBookingCancellationCommand;
using Bussiness.Features.CoreAssetBookingCancellation.Queries.GetAllCoreAssetBookingCancellationQuery;
using Bussiness.Features.CoreAssetBookingCancellation.Queries.GetCoreAssetBookingCancellationByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class CoreAssetBookingCancellationMapper : Profile
    {
        public CoreAssetBookingCancellationMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateCoreAssetBookingCancellationCommand, CoreAssetBookingCancellationDO>();
            CreateMap<UpdateCoreAssetBookingCancellationCommand, CoreAssetBookingCancellationDO>();
            CreateMap<DeleteCoreAssetBookingCancellationCommand, CoreAssetBookingCancellationDO>();

            //Response Mapper(s)
            CreateMap<CoreAssetBookingCancellationDO, GetAllCoreAssetBookingCancellationQueryDTO>()
            .ForMember(dest => dest.AssetBookingName, opt => opt.MapFrom(src => src.CoreAssetBooking.Name));
            CreateMap<CoreAssetBookingCancellationDO, GetCoreAssetBookingCancellationByIdDTO>()
            .ForMember(dest => dest.AssetBookingName, opt => opt.MapFrom(src => src.CoreAssetBooking.Name));
            CreateMap<CoreAssetBookingCancellationDO, CreateCoreAssetBookingCancellationCommandDTO>();
            CreateMap<CoreAssetBookingCancellationDO, UpdateCoreAssetBookingCancellationCommandDTO>();
            CreateMap<CoreAssetBookingCancellationDO, DeleteCoreAssetBookingCancellationCommandDTO>();
        }
    }
}
