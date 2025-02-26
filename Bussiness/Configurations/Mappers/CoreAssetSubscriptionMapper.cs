using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAssetSubscription.Commands.CreateCoreAssetSubscriptionCommand;
using Bussiness.Features.CoreAssetSubscription.Commands.DeleteCoreAssetSubscriptionCommand;
using Bussiness.Features.CoreAssetSubscription.Commands.UpdateCoreAssetSubscriptionCommand;
using Bussiness.Features.CoreAssetSubscription.Queries.GetAllCoreAssetSubscriptionQuery;
using Bussiness.Features.CoreAssetSubscription.Queries.GetCoreAssetSubscriptionByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class CoreAssetSubscriptionMapper : Profile
    {
        public CoreAssetSubscriptionMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateCoreAssetSubscriptionCommand, CoreAssetSubscriptionDO>();
            CreateMap<UpdateCoreAssetSubscriptionCommand, CoreAssetSubscriptionDO>();
            CreateMap<DeleteCoreAssetSubscriptionCommand, CoreAssetSubscriptionDO>();

            //Response Mapper(s)
            CreateMap<CoreAssetSubscriptionDO, GetAllCoreAssetSubscriptionQueryDTO>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.CoreAsset.Name));
            CreateMap<CoreAssetSubscriptionDO, GetCoreAssetSubscriptionByIdDTO>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.CoreAsset.Name));
            CreateMap<CoreAssetSubscriptionDO, CreateCoreAssetSubscriptionCommandDTO>();
            CreateMap<CoreAssetSubscriptionDO, UpdateCoreAssetSubscriptionCommandDTO>();
            CreateMap<CoreAssetSubscriptionDO, DeleteCoreAssetSubscriptionCommandDTO>();
        }
    
    }
}
