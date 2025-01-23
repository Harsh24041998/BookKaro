using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Subscription.Queries.GetAllSubscriptionQuery
{
    public class GetAllSubscriptionHandler : IRequestHandler<GetAllSubscriptionQuery, IEnumerable<GetAllSubscriptionDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public GetAllSubscriptionHandler(IUnitOfWork unitOfWork, IMapper mapper, ISubscriptionRepository subscriptionRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<IEnumerable<GetAllSubscriptionDTO>> Handle(GetAllSubscriptionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string propertiesToInclude = "SubscriptionType,Gender";
                var Subscriptions = await _subscriptionRepository.ReadAllAsync(propertiesToInclude, cancellationToken);

                var SubscriptionDTOs = _mapper.Map<IEnumerable<GetAllSubscriptionDTO>>(Subscriptions);
                return SubscriptionDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
