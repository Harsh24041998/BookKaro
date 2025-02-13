using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetBookingCancellation.Queries.GetCoreAssetBookingCancellationByIdQuery
{
    public class GetCoreAssetBookingCancellationByIdQueryHandler : IRequestHandler<GetCoreAssetBookingCancellationByIdQuery, GetCoreAssetBookingCancellationByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetBookingCancellationRepository _CoreAssetBookingCancellationRepository;

        #endregion

        #region Ctor

        public GetCoreAssetBookingCancellationByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetBookingCancellationRepository CoreAssetBookingCancellationRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetBookingCancellationRepository = CoreAssetBookingCancellationRepository;
        }

        #endregion

        #region methods

        public async Task<GetCoreAssetBookingCancellationByIdDTO> Handle(GetCoreAssetBookingCancellationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetBookingCancellationResponse = new GetCoreAssetBookingCancellationByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _CoreAssetBookingCancellationRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                CoreAssetBookingCancellationResponse = _mapper.Map<GetCoreAssetBookingCancellationByIdDTO>(response);
                return CoreAssetBookingCancellationResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
