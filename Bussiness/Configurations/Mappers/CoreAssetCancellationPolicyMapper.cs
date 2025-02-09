using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAssetCancellationPolicy.Commands.CreateCoreAssetCancellationPolicyCommand;
using Bussiness.Features.CoreAssetCancellationPolicy.Commands.DeleteCoreAssetCancellationPolicyCommand;
using Bussiness.Features.CoreAssetCancellationPolicy.Commands.UpdateCoreAssetCancellationPolicyCommand;
using Bussiness.Features.CoreAssetCancellationPolicy.Queries.GetAllCoreAssetCancellationPolicyQuery;
using Bussiness.Features.CoreAssetCancellationPolicy.Queries.GetCoreAssetCancellationPolicyByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class CoreAssetCancellationPolicyMapper : Profile
    {
        public CoreAssetCancellationPolicyMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateCoreAssetCancellationPolicyCommand, CoreAssetCancellationPolicyDO>();
            CreateMap<UpdateCoreAssetCancellationPolicyCommand, CoreAssetCancellationPolicyDO>();
            CreateMap<DeleteCoreAssetCancellationPolicyCommand, CoreAssetCancellationPolicyDO>();

            //Response Mapper(s)
            CreateMap<CoreAssetCancellationPolicyDO, GetAllCoreAssetCancellationPolicyDTO>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.CoreAsset.Name));
            CreateMap<CoreAssetCancellationPolicyDO, GetCoreAssetCancellationPolicyByIdDTO>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.CoreAsset.Name));
            CreateMap<CoreAssetCancellationPolicyDO, CreateCoreAssetCancellationPolicyCommandDTO>();
            CreateMap<CoreAssetCancellationPolicyDO, UpdateCoreAssetCancellationPolicyCommandDTO>();
            CreateMap<CoreAssetCancellationPolicyDO, DeleteCoreAssetCancellationPolicyCommandDTO>();
        }
    }
}
