using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetSubscription.Queries.GetAllCoreAssetSubscriptionQuery
{
    public class GetAllCoreAssetSubscriptionHandler : IRequestHandler<GetAllCoreAssetSubscriptionQuery, IEnumerable<GetAllCoreAssetSubscriptionQueryDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetSubscriptionRepository _CoreAssetSubscriptionRepository;

        #endregion

        #region Ctor

        public GetAllCoreAssetSubscriptionHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetSubscriptionRepository CoreAssetSubscriptionRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetSubscriptionRepository = CoreAssetSubscriptionRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllCoreAssetSubscriptionQueryDTO>> Handle(GetAllCoreAssetSubscriptionQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var CoreAssetSubscriptions = await _CoreAssetSubscriptionRepository.ReadAllAsync(null, cancellationToken);

                var CoreAssetSubscriptionDTOs = _mapper.Map<IEnumerable<GetAllCoreAssetSubscriptionQueryDTO>>(CoreAssetSubscriptions);
                return CoreAssetSubscriptionDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
