using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAssetBookingSlot.Commands.CreateCoreAssetBookingSlotCommand;
using Bussiness.Features.CoreAssetBookingSlot.Commands.DeleteCoreAssetBookingSlotCommand;
using Bussiness.Features.CoreAssetBookingSlot.Commands.UpdateCoreAssetBookingSlotCommand;
using Bussiness.Features.CoreAssetBookingSlot.Queries.GetAllCoreAssetBookingSlotQuery;
using Bussiness.Features.CoreAssetBookingSlot.Queries.GetCoreAssetBookingSlotByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class CoreAssetBookingSlotMapper : Profile
    {
        public CoreAssetBookingSlotMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateCoreAssetBookingSlotCommand, CoreAssetBookingSlotDO>();
            CreateMap<UpdateCoreAssetBookingSlotCommand, CoreAssetBookingSlotDO>();
            CreateMap<DeleteCoreAssetBookingSlotCommand, CoreAssetBookingSlotDO>();

            //Response Mapper(s)
            CreateMap<CoreAssetBookingSlotDO, GetAllCoreAssetBookingSlotQueryDTO>()
            .ForMember(dest => dest.AssetBookingName, opt => opt.MapFrom(src => src.CoreAssetBooking.Name));
            CreateMap<CoreAssetBookingSlotDO, GetCoreAssetBookingSlotByIdDTO>()
            .ForMember(dest => dest.AssetBookingName, opt => opt.MapFrom(src => src.CoreAssetBooking.Name));
            CreateMap<CoreAssetBookingSlotDO, CreateCoreAssetBookingSlotCommandDTO>();
            CreateMap<CoreAssetBookingSlotDO, UpdateCoreAssetBookingSlotCommandDTO>();
            CreateMap<CoreAssetBookingSlotDO, DeleteCoreAssetBookingSlotCommandDTO>();
        }
    }
}
