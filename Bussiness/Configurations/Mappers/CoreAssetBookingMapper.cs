using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAssetBooking.Commands.CreateCoreAssetBookingCommand;
using Bussiness.Features.CoreAssetBooking.Commands.DeleteCoreAssetBookingCommand;
using Bussiness.Features.CoreAssetBooking.Commands.UpdateCoreAssetBookingCommand;
using Bussiness.Features.CoreAssetBooking.Queries.GetAllCoreAssetBookingQuery;
using Bussiness.Features.CoreAssetBooking.Queries.GetCoreAssetBookingByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class CoreAssetBookingMapper : Profile
    {
        public CoreAssetBookingMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateCoreAssetBookingCommand, CoreAssetBookingDO>();
            CreateMap<UpdateCoreAssetBookingCommand, CoreAssetBookingDO>();
            CreateMap<DeleteCoreAssetBookingCommand, CoreAssetBookingDO>();

            //Response Mapper(s)
            CreateMap<CoreAssetBookingDO, GetAllCoreAssetBookingQueryDTO>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.CoreAsset.Name));
            CreateMap<CoreAssetBookingDO, GetCoreAssetBookingByIdDTO>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.CoreAsset.Name));
            CreateMap<CoreAssetBookingDO, CreateCoreAssetBookingCommandDTO>();
            CreateMap<CoreAssetBookingDO, UpdateCoreAssetBookingCommandDTO>();
            CreateMap<CoreAssetBookingDO, DeleteCoreAssetBookingCommandDTO>();
        }
    }
}
