using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Role.Queries.GetAllActiveRole
{
    public class GetAllActiveRoleHandler : IRequestHandler<GetAllActiveRoleQuery, IEnumerable<GetAllActiveRoleDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _RoleRepository;

        #endregion

        #region Ctor

        public GetAllActiveRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IRoleRepository RoleRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _RoleRepository = RoleRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllActiveRoleDTO>> Handle(GetAllActiveRoleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string propertiesToInclude = "";
                var Roles = (await _RoleRepository.GetAllActiveRole(propertiesToInclude, true, cancellationToken));

                var RoleDTOs = _mapper.Map<IEnumerable<GetAllActiveRoleDTO>>(Roles);
                return RoleDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
