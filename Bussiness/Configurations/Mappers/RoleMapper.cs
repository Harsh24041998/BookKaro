using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.Role.Commands.CreateRoleCommand;
using Bussiness.Features.Role.Commands.DeleteRoleCommand;
using Bussiness.Features.Role.Commands.UpdateRoleCommand;
using Bussiness.Features.Role.Queries.GetAllActiveRole;
using Bussiness.Features.Role.Queries.GetAllRoleQuery;
using Bussiness.Features.Role.Queries.GetRoleByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateRoleCommand, RoleDO>();
            CreateMap<UpdateRoleCommand, RoleDO>();
            CreateMap<DeleteRoleCommand, RoleDO>();

            //Response Mapper(s)
            CreateMap<RoleDO, GetAllRoleDTO>();
            CreateMap<RoleDO, GetAllActiveRoleDTO>();
            CreateMap<RoleDO, GetRoleByIdDTO>();
            CreateMap<RoleDO, CreateRoleCommandDTO>();
            CreateMap<RoleDO, UpdateRoleCommandDTO>();
            CreateMap<RoleDO, DeleteRoleCommandDTO>();
        }
    }
}
