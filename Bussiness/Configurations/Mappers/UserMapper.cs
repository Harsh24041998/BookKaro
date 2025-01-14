using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.User.Commands.CreateUserCommand;
using Bussiness.Features.User.Commands.DeleteUserCommand;
using Bussiness.Features.User.Commands.UpdateUserCommand;
using Bussiness.Features.User.Queries.GetAllUserQuery;
using Bussiness.Features.User.Queries.GetUserByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateUserCommand, UserDO>();
            CreateMap<UpdateUserCommand, UserDO>();
            CreateMap<DeleteUserCommand, UserDO>();

            //Response Mapper(s)
            CreateMap<UserDO, GetAllUserDTO>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Name));
            CreateMap<UserDO, GetUserByIdDTO>();
            CreateMap<UserDO, CreateUserCommandDTO>();
            CreateMap<UserDO, UpdateUserCommandDTO>();
            CreateMap<UserDO, DeleteUserCommandDTO>();
        }
    }
}
