using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Organization.Queries.GetAllOrganizationQuery
{
    public class GetAllOrganizationHandler : IRequestHandler<GetAllOrganizationQuery, IEnumerable<GetAllOrganizationDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrganizationRepository _OrganizationRepository;

        #endregion

        #region Ctor

        public GetAllOrganizationHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrganizationRepository OrganizationRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _OrganizationRepository = OrganizationRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllOrganizationDTO>> Handle(GetAllOrganizationQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var Organizations = await _OrganizationRepository.ReadAllAsync(null, cancellationToken);

                var OrganizationDTOs = _mapper.Map<IEnumerable<GetAllOrganizationDTO>>(Organizations);
                return OrganizationDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
