using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetSubscription.Queries.GetCoreAssetSubscriptionByIdQuery
{
    public class GetCoreAssetSubscriptionByIdQueryHandler : IRequestHandler<GetCoreAssetSubscriptionByIdQuery, GetCoreAssetSubscriptionByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetSubscriptionRepository _CoreAssetSubscriptionRepository;

        #endregion

        #region Ctor

        public GetCoreAssetSubscriptionByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetSubscriptionRepository CoreAssetSubscriptionRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetSubscriptionRepository = CoreAssetSubscriptionRepository;
        }

        #endregion

        #region methods

        public async Task<GetCoreAssetSubscriptionByIdDTO> Handle(GetCoreAssetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetSubscriptionResponse = new GetCoreAssetSubscriptionByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _CoreAssetSubscriptionRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                CoreAssetSubscriptionResponse = _mapper.Map<GetCoreAssetSubscriptionByIdDTO>(response);
                return CoreAssetSubscriptionResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
