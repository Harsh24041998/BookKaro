using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.OrganizationRole.Queries.GetAllOrganizationRoleQuery
{
    public class GetAllOrganizationRoleHandler : IRequestHandler<GetAllOrganizationRoleQuery, IEnumerable<GetAllOrganizationRoleDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrganizationRoleRepository _OrganizationRoleRepository;

        #endregion

        #region Ctor

        public GetAllOrganizationRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrganizationRoleRepository OrganizationRoleRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _OrganizationRoleRepository = OrganizationRoleRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllOrganizationRoleDTO>> Handle(GetAllOrganizationRoleQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var OrganizationRoles = await _OrganizationRoleRepository.ReadAllAsync(null, cancellationToken);

                var OrganizationRoleDTOs = _mapper.Map<IEnumerable<GetAllOrganizationRoleDTO>>(OrganizationRoles);
                return OrganizationRoleDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
