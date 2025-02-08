using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.OrganizationRole.Queries.GetOrganizationRoleByIdQuery
{
    public class GetOrganizationRoleByIdQueryHandler : IRequestHandler<GetOrganizationRoleByIdQuery, GetOrganizationRoleByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrganizationRoleRepository _OrganizationRoleRepository;

        #endregion

        #region Ctor

        public GetOrganizationRoleByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrganizationRoleRepository OrganizationRoleRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _OrganizationRoleRepository = OrganizationRoleRepository;
        }

        #endregion

        #region methods

        public async Task<GetOrganizationRoleByIdDTO> Handle(GetOrganizationRoleByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var OrganizationRoleResponse = new GetOrganizationRoleByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _OrganizationRoleRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                OrganizationRoleResponse = _mapper.Map<GetOrganizationRoleByIdDTO>(response);
                return OrganizationRoleResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
