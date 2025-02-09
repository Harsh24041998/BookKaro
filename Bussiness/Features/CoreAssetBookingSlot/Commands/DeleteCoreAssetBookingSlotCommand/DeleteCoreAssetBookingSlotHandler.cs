using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.CoreAssetBookingSlot.Commands.DeleteCoreAssetBookingSlotCommand
{
    public class DeleteCoreAssetBookingSlotHandler : IRequestHandler<DeleteCoreAssetBookingSlotCommand, DeleteCoreAssetBookingSlotCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetBookingSlotRepository _CoreAssetBookingSlotRepository;

        #endregion

        #region Ctor

        public DeleteCoreAssetBookingSlotHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetBookingSlotRepository CoreAssetBookingSlotRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetBookingSlotRepository = CoreAssetBookingSlotRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteCoreAssetBookingSlotCommandDTO> Handle(DeleteCoreAssetBookingSlotCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteCoreAssetBookingSlotCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetBookingSlotDO = _mapper.Map<CoreAssetBookingSlotDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _CoreAssetBookingSlotRepository.Delete(convertToCoreAssetBookingSlotDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToCoreAssetBookingSlotDtO = _mapper.Map<DeleteCoreAssetBookingSlotCommandDTO>(result);
                return convertToCoreAssetBookingSlotDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
