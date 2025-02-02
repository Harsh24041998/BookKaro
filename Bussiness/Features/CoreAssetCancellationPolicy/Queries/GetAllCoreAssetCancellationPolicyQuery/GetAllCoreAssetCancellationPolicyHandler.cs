using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetCancellationPolicy.Queries.GetAllCoreAssetCancellationPolicyQuery
{
    public class GetAllCoreAssetCancellationPolicyHandler : IRequestHandler<GetAllCoreAssetCancellationPolicyQuery, IEnumerable<GetAllCoreAssetCancellationPolicyDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetCancellationPolicyRepository _CoreAssetCancellationPolicyRepository;

        #endregion

        #region Ctor

        public GetAllCoreAssetCancellationPolicyHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetCancellationPolicyRepository CoreAssetCancellationPolicyRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetCancellationPolicyRepository = CoreAssetCancellationPolicyRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllCoreAssetCancellationPolicyDTO>> Handle(GetAllCoreAssetCancellationPolicyQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var CoreAssetCancellationPolicys = await _CoreAssetCancellationPolicyRepository.ReadAllAsync(null, cancellationToken);

                var CoreAssetCancellationPolicyDTOs = _mapper.Map<IEnumerable<GetAllCoreAssetCancellationPolicyDTO>>(CoreAssetCancellationPolicys);
                return CoreAssetCancellationPolicyDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
