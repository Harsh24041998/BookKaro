using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.CoreAsset.Commands.DeleteCoreAssetCommand
{
    public class DeleteCoreAssetHandler : IRequestHandler<DeleteCoreAssetCommand, DeleteCoreAssetCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetRepository _CoreAssetRepository;

        #endregion

        #region Ctor

        public DeleteCoreAssetHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetRepository CoreAssetRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetRepository = CoreAssetRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteCoreAssetCommandDTO> Handle(DeleteCoreAssetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteCoreAssetCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetDO = _mapper.Map<CoreAssetDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _CoreAssetRepository.Delete(convertToCoreAssetDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToCoreAssetDtO = _mapper.Map<DeleteCoreAssetCommandDTO>(result);
                return convertToCoreAssetDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
