using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.CoreAssetBooking.Commands.DeleteCoreAssetBookingCommand
{
    public class DeleteCoreAssetBookingHandler : IRequestHandler<DeleteCoreAssetBookingCommand, DeleteCoreAssetBookingCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetBookingRepository _CoreAssetBookingRepository;

        #endregion

        #region Ctor

        public DeleteCoreAssetBookingHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetBookingRepository CoreAssetBookingRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetBookingRepository = CoreAssetBookingRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteCoreAssetBookingCommandDTO> Handle(DeleteCoreAssetBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteCoreAssetBookingCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetBookingDO = _mapper.Map<CoreAssetBookingDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _CoreAssetBookingRepository.Delete(convertToCoreAssetBookingDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToCoreAssetBookingDtO = _mapper.Map<DeleteCoreAssetBookingCommandDTO>(result);
                return convertToCoreAssetBookingDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
