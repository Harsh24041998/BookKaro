using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.Industry.Commands.CreateIndustryCommand;
using Bussiness.Features.Industry.Commands.DeleteIndustryCommand;
using Bussiness.Features.Industry.Commands.UpdateIndustryCommand;
using Bussiness.Features.Industry.Queries.GetAllIndustryQuery;
using Bussiness.Features.Industry.Queries.GetIndustryByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class IndustryMapper : Profile
    {
        public IndustryMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateIndustryCommand, IndustryDO>();
            CreateMap<UpdateIndustryCommand, IndustryDO>();
            CreateMap<DeleteIndustryCommand, IndustryDO>();

            //Response Mapper(s)
            CreateMap<IndustryDO, GetAllIndustryDTO>();
            CreateMap<IndustryDO, GetIndustryByIdDTO>();
            CreateMap<IndustryDO, CreateIndustryCommandDTO>();
            CreateMap<IndustryDO, UpdateIndustryCommandDTO>();
            CreateMap<IndustryDO, DeleteIndustryCommandDTO>();
        }
    }
}
