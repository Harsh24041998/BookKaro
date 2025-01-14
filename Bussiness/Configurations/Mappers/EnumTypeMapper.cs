using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.EnumType.Commands.CreateEnumTypeCommand;
using Bussiness.Features.EnumType.Commands.DeleteEnumTypeCommand;
using Bussiness.Features.EnumType.Commands.UpdateEnumTypeCommand;
using Bussiness.Features.EnumType.Queries.GetAllEnumTypeQuery;
using Bussiness.Features.EnumType.Queries.GetEnumTypeByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class EnumTypeMapper : Profile
    {
        public EnumTypeMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateEnumTypeCommand, EnumTypeDO>();
            CreateMap<UpdateEnumTypeCommand, EnumTypeDO>();
            CreateMap<DeleteEnumTypeCommand, EnumTypeDO>();

            //Response Mapper(s)
            CreateMap<EnumTypeDO, GetAllEnumTypeDTO>();
            CreateMap<EnumTypeDO, GetEnumTypeByIdDTO>();
            CreateMap<EnumTypeDO, CreateEnumTypeCommandDTO>();
            CreateMap<EnumTypeDO, UpdateEnumTypeCommandDTO>();
            CreateMap<EnumTypeDO, DeleteEnumTypeCommandDTO>();
        }
    }
}
