using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAsset.Commands.CreateCoreAssetCommand;
using Bussiness.Features.CoreAsset.Commands.DeleteCoreAssetCommand;
using Bussiness.Features.CoreAsset.Commands.UpdateCoreAssetCommand;
using Bussiness.Features.CoreAsset.Queries.GetAllCoreAssetQuery;
using Bussiness.Features.CoreAsset.Queries.GetCoreAssetByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class CoreAssetMapper : Profile
    {
        public CoreAssetMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateCoreAssetCommand, CoreAssetDO>();
            CreateMap<UpdateCoreAssetCommand, CoreAssetDO>();
            CreateMap<DeleteCoreAssetCommand, CoreAssetDO>();

            //Response Mapper(s)
            CreateMap<CoreAssetDO, GetAllCoreAssetDTO>();
            CreateMap<CoreAssetDO, GetCoreAssetByIdDTO>();
            CreateMap<CoreAssetDO, CreateCoreAssetCommandDTO>();
            CreateMap<CoreAssetDO, UpdateCoreAssetCommandDTO>();
            CreateMap<CoreAssetDO, DeleteCoreAssetCommandDTO>();
        }
    }
}
