using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Role.Queries.GetAllRoleQuery
{
    public class GetAllRoleHandler : IRequestHandler<GetAllRoleQuery, IEnumerable<GetAllRoleDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _RoleRepository;

        #endregion

        #region Ctor

        public GetAllRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IRoleRepository RoleRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _RoleRepository = RoleRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllRoleDTO>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string propertiesToInclude = "";
                var Roles = await _RoleRepository.ReadAllAsync(propertiesToInclude, cancellationToken);

                var RoleDTOs = _mapper.Map<IEnumerable<GetAllRoleDTO>>(Roles);
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
