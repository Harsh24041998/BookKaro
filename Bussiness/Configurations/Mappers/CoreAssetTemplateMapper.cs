using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAssetTemplate.Commands.CreateCoreAssetTemplateCommand;
using Bussiness.Features.CoreAssetTemplate.Commands.DeleteCoreAssetTemplateCommand;
using Bussiness.Features.CoreAssetTemplate.Commands.UpdateCoreAssetTemplateCommand;
using Bussiness.Features.CoreAssetTemplate.Queries.GetAllCoreAssetTemplateQuery;
using Bussiness.Features.CoreAssetTemplate.Queries.GetCoreAssetTemplateByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class CoreAssetTemplateMapper : Profile
    {
        public CoreAssetTemplateMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateCoreAssetTemplateCommand, CoreAssetTemplateDO>();
            CreateMap<UpdateCoreAssetTemplateCommand, CoreAssetTemplateDO>();
            CreateMap<DeleteCoreAssetTemplateCommand, CoreAssetTemplateDO>();

            //Response Mapper(s)
            CreateMap<CoreAssetTemplateDO, GetAllCoreAssetTemplateDTO>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.CoreAsset.Name))
            .ForMember(dest => dest.DayEnumValue, opt => opt.MapFrom(src => src.EnumValue.Name));
            CreateMap<CoreAssetTemplateDO, GetCoreAssetTemplateByIdDTO>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.CoreAsset.Name))
            .ForMember(dest => dest.DayEnumValue, opt => opt.MapFrom(src => src.EnumValue.Name));
            CreateMap<CoreAssetTemplateDO, CreateCoreAssetTemplateCommandDTO>();
            CreateMap<CoreAssetTemplateDO, UpdateCoreAssetTemplateCommandDTO>();
            CreateMap<CoreAssetTemplateDO, DeleteCoreAssetTemplateCommandDTO>();
        }
    }
}
