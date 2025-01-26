using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAssetCustomTemplate.Commands.CreateCoreAssetCustomTemplateCommand;
using Bussiness.Features.CoreAssetCustomTemplate.Commands.DeleteCoreAssetCustomTemplateCommand;
using Bussiness.Features.CoreAssetCustomTemplate.Commands.UpdateCoreAssetCustomTemplateCommand;
using Bussiness.Features.CoreAssetCustomTemplate.Queries.GetAllCoreAssetCustomTemplateQuery;
using Bussiness.Features.CoreAssetCustomTemplate.Queries.GetCoreAssetCustomTemplateByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class CoreAssetCustomTemplateMapper : Profile
    {
        public CoreAssetCustomTemplateMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateCoreAssetCustomTemplateCommand, CoreAssetCustomTemplateDO>();
            CreateMap<UpdateCoreAssetCustomTemplateCommand, CoreAssetCustomTemplateDO>();
            CreateMap<DeleteCoreAssetCustomTemplateCommand, CoreAssetCustomTemplateDO>();

            //Response Mapper(s)
            CreateMap<CoreAssetCustomTemplateDO, GetAllCoreAssetCustomTemplateDTO>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.CoreAsset.Name));
            CreateMap<CoreAssetCustomTemplateDO, GetCoreAssetCustomTemplateByIdDTO>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.CoreAsset.Name));
            CreateMap<CoreAssetCustomTemplateDO, CreateCoreAssetCustomTemplateCommandDTO>();
            CreateMap<CoreAssetCustomTemplateDO, UpdateCoreAssetCustomTemplateCommandDTO>();
            CreateMap<CoreAssetCustomTemplateDO, DeleteCoreAssetCustomTemplateCommandDTO>();
        }
    }
}
