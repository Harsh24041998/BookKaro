using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetTemplate.Queries.GetAllCoreAssetTemplateQuery
{
    public class GetAllCoreAssetTemplateHandler : IRequestHandler<GetAllCoreAssetTemplateQuery, IEnumerable<GetAllCoreAssetTemplateDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetTemplateRepository _CoreAssetTemplateRepository;

        #endregion

        #region Ctor

        public GetAllCoreAssetTemplateHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetTemplateRepository CoreAssetTemplateRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetTemplateRepository = CoreAssetTemplateRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllCoreAssetTemplateDTO>> Handle(GetAllCoreAssetTemplateQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var CoreAssetTemplates = await _CoreAssetTemplateRepository.ReadAllAsync(null, cancellationToken);

                var CoreAssetTemplateDTOs = _mapper.Map<IEnumerable<GetAllCoreAssetTemplateDTO>>(CoreAssetTemplates);
                return CoreAssetTemplateDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
