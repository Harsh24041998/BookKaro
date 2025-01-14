using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.Gender.Commands.CreateGenderCommand;
using Bussiness.Features.Gender.Commands.DeleteGenderCommand;
using Bussiness.Features.Gender.Commands.UpdateGenderCommand;
using Bussiness.Features.Gender.Queries.GetAllGenderQuery;
using Bussiness.Features.Gender.Queries.GetGenderByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class GenderMapper : Profile
    {
        public GenderMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateGenderCommand, GenderDO>();
            CreateMap<UpdateGenderCommand, GenderDO>();
            CreateMap<DeleteGenderCommand, GenderDO>();

            //Response Mapper(s)
            CreateMap<GenderDO, GetAllGenderDTO>();
            CreateMap<GenderDO, GetGenderByIdDTO>();
            CreateMap<GenderDO, CreateGenderCommandDTO>();
            CreateMap<GenderDO, UpdateGenderCommandDTO>();
            CreateMap<GenderDO, DeleteGenderCommandDTO>();
        }
    }
}
