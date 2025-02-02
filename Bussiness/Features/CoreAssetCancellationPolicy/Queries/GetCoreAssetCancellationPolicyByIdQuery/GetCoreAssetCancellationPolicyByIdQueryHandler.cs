using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetCancellationPolicy.Queries.GetCoreAssetCancellationPolicyByIdQuery
{
    public class GetCoreAssetCancellationPolicyByIdQueryHandler : IRequestHandler<GetCoreAssetCancellationPolicyByIdQuery, GetCoreAssetCancellationPolicyByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetCancellationPolicyRepository _CoreAssetCancellationPolicyRepository;

        #endregion

        #region Ctor

        public GetCoreAssetCancellationPolicyByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetCancellationPolicyRepository CoreAssetCancellationPolicyRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetCancellationPolicyRepository = CoreAssetCancellationPolicyRepository;
        }

        #endregion

        #region methods

        public async Task<GetCoreAssetCancellationPolicyByIdDTO> Handle(GetCoreAssetCancellationPolicyByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetCancellationPolicyResponse = new GetCoreAssetCancellationPolicyByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _CoreAssetCancellationPolicyRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                CoreAssetCancellationPolicyResponse = _mapper.Map<GetCoreAssetCancellationPolicyByIdDTO>(response);
                return CoreAssetCancellationPolicyResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
