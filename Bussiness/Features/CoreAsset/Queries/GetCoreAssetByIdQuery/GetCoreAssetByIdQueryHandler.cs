using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAsset.Queries.GetCoreAssetByIdQuery
{
    public class GetCoreAssetByIdQueryHandler : IRequestHandler<GetCoreAssetByIdQuery, GetCoreAssetByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetRepository _CoreAssetRepository;

        #endregion

        #region Ctor

        public GetCoreAssetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetRepository CoreAssetRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetRepository = CoreAssetRepository;
        }

        #endregion

        #region methods

        public async Task<GetCoreAssetByIdDTO> Handle(GetCoreAssetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetResponse = new GetCoreAssetByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _CoreAssetRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                CoreAssetResponse = _mapper.Map<GetCoreAssetByIdDTO>(response);
                return CoreAssetResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
