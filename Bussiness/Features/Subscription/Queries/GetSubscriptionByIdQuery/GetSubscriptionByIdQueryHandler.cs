using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Subscription.Queries.GetSubscriptionByIdQuery
{
    public class GetSubscriptionByIdQueryHandler : IRequestHandler<GetSubscriptionByIdQuery, GetSubscriptionByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _SubscriptionRepository;

        #endregion

        #region Ctor

        public GetSubscriptionByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ISubscriptionRepository SubscriptionRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _SubscriptionRepository = SubscriptionRepository;
        }

        #endregion

        #region methods

        public async Task<GetSubscriptionByIdDTO> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var SubscriptionResponse = new GetSubscriptionByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _SubscriptionRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                SubscriptionResponse = _mapper.Map<GetSubscriptionByIdDTO>(response);
                return SubscriptionResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
