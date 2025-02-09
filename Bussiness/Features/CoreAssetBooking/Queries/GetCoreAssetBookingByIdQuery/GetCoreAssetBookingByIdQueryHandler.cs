using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetBooking.Queries.GetCoreAssetBookingByIdQuery
{
    public class GetCoreAssetBookingByIdQueryHandler : IRequestHandler<GetCoreAssetBookingByIdQuery, GetCoreAssetBookingByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetBookingRepository _CoreAssetBookingRepository;

        #endregion

        #region Ctor

        public GetCoreAssetBookingByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetBookingRepository CoreAssetBookingRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetBookingRepository = CoreAssetBookingRepository;
        }

        #endregion

        #region methods

        public async Task<GetCoreAssetBookingByIdDTO> Handle(GetCoreAssetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetBookingResponse = new GetCoreAssetBookingByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _CoreAssetBookingRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                CoreAssetBookingResponse = _mapper.Map<GetCoreAssetBookingByIdDTO>(response);
                return CoreAssetBookingResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
