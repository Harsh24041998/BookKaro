using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.CoreAssetSubscription.Commands.DeleteCoreAssetSubscriptionCommand
{
    public class DeleteCoreAssetSubscriptionHandler : IRequestHandler<DeleteCoreAssetSubscriptionCommand, DeleteCoreAssetSubscriptionCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetSubscriptionRepository _CoreAssetSubscriptionRepository;

        #endregion

        #region Ctor

        public DeleteCoreAssetSubscriptionHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetSubscriptionRepository CoreAssetSubscriptionRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetSubscriptionRepository = CoreAssetSubscriptionRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteCoreAssetSubscriptionCommandDTO> Handle(DeleteCoreAssetSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteCoreAssetSubscriptionCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetSubscriptionDO = _mapper.Map<CoreAssetSubscriptionDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _CoreAssetSubscriptionRepository.Delete(convertToCoreAssetSubscriptionDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToCoreAssetSubscriptionDtO = _mapper.Map<DeleteCoreAssetSubscriptionCommandDTO>(result);
                return convertToCoreAssetSubscriptionDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
