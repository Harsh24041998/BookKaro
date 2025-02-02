using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.CoreAssetCancellationPolicy.Commands.DeleteCoreAssetCancellationPolicyCommand
{
    public class DeleteCoreAssetCancellationPolicyHandler : IRequestHandler<DeleteCoreAssetCancellationPolicyCommand, DeleteCoreAssetCancellationPolicyCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetCancellationPolicyRepository _CoreAssetCancellationPolicyRepository;

        #endregion

        #region Ctor

        public DeleteCoreAssetCancellationPolicyHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetCancellationPolicyRepository CoreAssetCancellationPolicyRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetCancellationPolicyRepository = CoreAssetCancellationPolicyRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteCoreAssetCancellationPolicyCommandDTO> Handle(DeleteCoreAssetCancellationPolicyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteCoreAssetCancellationPolicyCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetCancellationPolicyDO = _mapper.Map<CoreAssetCancellationPolicyDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _CoreAssetCancellationPolicyRepository.Delete(convertToCoreAssetCancellationPolicyDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToCoreAssetCancellationPolicyDtO = _mapper.Map<DeleteCoreAssetCancellationPolicyCommandDTO>(result);
                return convertToCoreAssetCancellationPolicyDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
