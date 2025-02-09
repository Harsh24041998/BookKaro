using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetBookingSlot.Queries.GetAllCoreAssetBookingSlotQuery
{
    public class GetAllCoreAssetBookingSlotHandler : IRequestHandler<GetAllCoreAssetBookingSlotQuery, IEnumerable<GetAllCoreAssetBookingSlotQueryDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetBookingSlotRepository _CoreAssetBookingSlotRepository;

        #endregion

        #region Ctor

        public GetAllCoreAssetBookingSlotHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetBookingSlotRepository CoreAssetBookingSlotRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetBookingSlotRepository = CoreAssetBookingSlotRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllCoreAssetBookingSlotQueryDTO>> Handle(GetAllCoreAssetBookingSlotQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var CoreAssetBookingSlots = await _CoreAssetBookingSlotRepository.ReadAllAsync(null, cancellationToken);

                var CoreAssetBookingSlotDTOs = _mapper.Map<IEnumerable<GetAllCoreAssetBookingSlotQueryDTO>>(CoreAssetBookingSlots);
                return CoreAssetBookingSlotDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
