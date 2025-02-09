using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetBooking.Queries.GetAllCoreAssetBookingQuery
{
    public class GetAllCoreAssetBookingHandler : IRequestHandler<GetAllCoreAssetBookingQuery, IEnumerable<GetAllCoreAssetBookingQueryDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetBookingRepository _CoreAssetBookingRepository;

        #endregion

        #region Ctor

        public GetAllCoreAssetBookingHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetBookingRepository CoreAssetBookingRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetBookingRepository = CoreAssetBookingRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllCoreAssetBookingQueryDTO>> Handle(GetAllCoreAssetBookingQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var CoreAssetBookings = await _CoreAssetBookingRepository.ReadAllAsync(null, cancellationToken);

                var CoreAssetBookingDTOs = _mapper.Map<IEnumerable<GetAllCoreAssetBookingQueryDTO>>(CoreAssetBookings);
                return CoreAssetBookingDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
