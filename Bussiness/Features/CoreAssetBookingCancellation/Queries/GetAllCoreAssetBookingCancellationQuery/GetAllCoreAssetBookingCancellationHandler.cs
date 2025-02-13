using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetBookingCancellation.Queries.GetAllCoreAssetBookingCancellationQuery
{
    public class GetAllCoreAssetBookingCancellationHandler : IRequestHandler<GetAllCoreAssetBookingCancellationQuery, IEnumerable<GetAllCoreAssetBookingCancellationQueryDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetBookingCancellationRepository _CoreAssetBookingCancellationRepository;

        #endregion

        #region Ctor

        public GetAllCoreAssetBookingCancellationHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetBookingCancellationRepository CoreAssetBookingCancellationRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetBookingCancellationRepository = CoreAssetBookingCancellationRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllCoreAssetBookingCancellationQueryDTO>> Handle(GetAllCoreAssetBookingCancellationQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var CoreAssetBookingCancellations = await _CoreAssetBookingCancellationRepository.ReadAllAsync(null, cancellationToken);

                var CoreAssetBookingCancellationDTOs = _mapper.Map<IEnumerable<GetAllCoreAssetBookingCancellationQueryDTO>>(CoreAssetBookingCancellations);
                return CoreAssetBookingCancellationDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
