using AutoMapper;
using Bussiness.Contracts;
using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using Bussiness.Enums;
using Bussiness.Features.User.Commands.CreateUserCommand;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bussiness.Features.Subscription.Commands.CreateSubscriptionCommand
{
    public class CreateSubscriptionHandler : IRequestHandler<CreateSubscriptionCommand, CreateSubscriptionCommandDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public CreateSubscriptionHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, ISubscriptionRepository subscriptionRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<CreateSubscriptionCommandDTO> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                SubscriptionDO Subscription = _mapper.Map<SubscriptionDO>(request);

                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var SubscriptionClaims = _httpContextAccessor.HttpContext.User.Claims;
                //var firstName = SubscriptionClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value;
                //var LastName = SubscriptionClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Nickname)?.Value;
                //var empCode = SubscriptionClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;
                //var email = SubscriptionClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email || c.Type == ClaimTypes.Email)?.Value;
                //var phoneNumber = SubscriptionClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.PhoneNumber)?.Value;
                //var SubscriptionId = SubscriptionClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId || c.Type == ClaimTypes.NameIdentifier)?.Value;


                Subscription.CreatedBy = "Harsh";//empCode.ToString();

                var result = await _unitOfWork.SubscriptionRepository.Create(Subscription, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return _mapper.Map<CreateSubscriptionCommandDTO>(result);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);

                throw new Exception(ex.Message);
            }
        }
    }
}
