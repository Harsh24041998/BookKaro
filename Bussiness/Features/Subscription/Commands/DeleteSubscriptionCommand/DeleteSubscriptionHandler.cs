using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.DomainObjects;
using AutoMapper;

namespace Bussiness.Features.Subscription.Commands.DeleteSubscriptionCommand
{
    public class DeleteSubscriptionHandler : IRequestHandler<DeleteSubscriptionCommand, DeleteSubscriptionCommandDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public DeleteSubscriptionHandler(IUnitOfWork unitOfWork, IMapper mapper, ISubscriptionRepository subscriptionRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<DeleteSubscriptionCommandDTO> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteSubscriptionCommandDTO();
                var requestModel = request.Id;
                var convertToSubscriptionDO = _mapper.Map<SubscriptionDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _subscriptionRepository.Delete(convertToSubscriptionDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToSubscriptionDtO = _mapper.Map<DeleteSubscriptionCommandDTO>(result);
                return convertToSubscriptionDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
