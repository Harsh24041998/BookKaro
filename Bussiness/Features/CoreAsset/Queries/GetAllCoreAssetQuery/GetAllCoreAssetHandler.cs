using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAsset.Queries.GetAllCoreAssetQuery
{
    public class GetAllCoreAssetHandler : IRequestHandler<GetAllCoreAssetQuery, IEnumerable<GetAllCoreAssetDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetRepository _CoreAssetRepository;

        #endregion

        #region Ctor

        public GetAllCoreAssetHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetRepository CoreAssetRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetRepository = CoreAssetRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllCoreAssetDTO>> Handle(GetAllCoreAssetQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var CoreAssets = await _CoreAssetRepository.ReadAllAsync(null, cancellationToken);

                var CoreAssetDTOs = _mapper.Map<IEnumerable<GetAllCoreAssetDTO>>(CoreAssets);
                return CoreAssetDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
