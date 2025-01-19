using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Organization.Queries.GetOrganizationByIdQuery
{
    public class GetOrganizationByIdQueryHandler : IRequestHandler<GetOrganizationByIdQuery, GetOrganizationByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrganizationRepository _OrganizationRepository;

        #endregion

        #region Ctor

        public GetOrganizationByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrganizationRepository OrganizationRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _OrganizationRepository = OrganizationRepository;
        }

        #endregion

        #region methods

        public async Task<GetOrganizationByIdDTO> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var OrganizationResponse = new GetOrganizationByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _OrganizationRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                OrganizationResponse = _mapper.Map<GetOrganizationByIdDTO>(response);
                return OrganizationResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
