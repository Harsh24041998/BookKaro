using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.EnumValue.Commands.CreateEnumValueCommand;
using Bussiness.Features.EnumValue.Commands.DeleteEnumValueCommand;
using Bussiness.Features.EnumValue.Commands.UpdateEnumValueCommand;
using Bussiness.Features.EnumValue.Queries.GetAllEnumValueQuery;
using Bussiness.Features.EnumValue.Queries.GetEnumValueByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class EnumValueMapper : Profile
    {
        public EnumValueMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateEnumValueCommand, EnumValueDO>();
            CreateMap<UpdateEnumValueCommand, EnumValueDO>();
            CreateMap<DeleteEnumValueCommand, EnumValueDO>();

            //Response Mapper(s)
            CreateMap<EnumValueDO, GetAllEnumValueDTO>();
            CreateMap<EnumValueDO, GetEnumValueByIdDTO>();
            CreateMap<EnumValueDO, CreateEnumValueCommandDTO>();
            CreateMap<EnumValueDO, UpdateEnumValueCommandDTO>();
            CreateMap<EnumValueDO, DeleteEnumValueCommandDTO>();
        }
    }
}
