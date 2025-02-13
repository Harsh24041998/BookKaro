using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.CoreAssetBookingCancellation.Commands.DeleteCoreAssetBookingCancellationCommand
{
    public class DeleteCoreAssetBookingCancellationHandler : IRequestHandler<DeleteCoreAssetBookingCancellationCommand, DeleteCoreAssetBookingCancellationCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetBookingCancellationRepository _CoreAssetBookingCancellationRepository;

        #endregion

        #region Ctor

        public DeleteCoreAssetBookingCancellationHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetBookingCancellationRepository CoreAssetBookingCancellationRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetBookingCancellationRepository = CoreAssetBookingCancellationRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteCoreAssetBookingCancellationCommandDTO> Handle(DeleteCoreAssetBookingCancellationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteCoreAssetBookingCancellationCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetBookingCancellationDO = _mapper.Map<CoreAssetBookingCancellationDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _CoreAssetBookingCancellationRepository.Delete(convertToCoreAssetBookingCancellationDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToCoreAssetBookingCancellationDtO = _mapper.Map<DeleteCoreAssetBookingCancellationCommandDTO>(result);
                return convertToCoreAssetBookingCancellationDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
