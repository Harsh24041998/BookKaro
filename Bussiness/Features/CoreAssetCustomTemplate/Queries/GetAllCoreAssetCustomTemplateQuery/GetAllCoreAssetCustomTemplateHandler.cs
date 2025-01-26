using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetCustomTemplate.Queries.GetAllCoreAssetCustomTemplateQuery
{
    public class GetAllCoreAssetCustomTemplateHandler : IRequestHandler<GetAllCoreAssetCustomTemplateQuery, IEnumerable<GetAllCoreAssetCustomTemplateDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetCustomTemplateRepository _CoreAssetCustomTemplateRepository;

        #endregion

        #region Ctor

        public GetAllCoreAssetCustomTemplateHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetCustomTemplateRepository CoreAssetCustomTemplateRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetCustomTemplateRepository = CoreAssetCustomTemplateRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllCoreAssetCustomTemplateDTO>> Handle(GetAllCoreAssetCustomTemplateQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var CoreAssetCustomTemplates = await _CoreAssetCustomTemplateRepository.ReadAllAsync(null, cancellationToken);

                var CoreAssetCustomTemplateDTOs = _mapper.Map<IEnumerable<GetAllCoreAssetCustomTemplateDTO>>(CoreAssetCustomTemplates);
                return CoreAssetCustomTemplateDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
