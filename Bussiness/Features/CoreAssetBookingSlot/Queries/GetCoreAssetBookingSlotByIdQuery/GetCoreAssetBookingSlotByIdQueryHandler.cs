using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetBookingSlot.Queries.GetCoreAssetBookingSlotByIdQuery
{
    public class GetCoreAssetBookingSlotByIdQueryHandler : IRequestHandler<GetCoreAssetBookingSlotByIdQuery, GetCoreAssetBookingSlotByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetBookingSlotRepository _CoreAssetBookingSlotRepository;

        #endregion

        #region Ctor

        public GetCoreAssetBookingSlotByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetBookingSlotRepository CoreAssetBookingSlotRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetBookingSlotRepository = CoreAssetBookingSlotRepository;
        }

        #endregion

        #region methods

        public async Task<GetCoreAssetBookingSlotByIdDTO> Handle(GetCoreAssetBookingSlotByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetBookingSlotResponse = new GetCoreAssetBookingSlotByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _CoreAssetBookingSlotRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                CoreAssetBookingSlotResponse = _mapper.Map<GetCoreAssetBookingSlotByIdDTO>(response);
                return CoreAssetBookingSlotResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
