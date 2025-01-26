using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetCustomTemplate.Queries.GetCoreAssetCustomTemplateByIdQuery
{
    public class GetCoreAssetCustomTemplateByIdQueryHandler : IRequestHandler<GetCoreAssetCustomTemplateByIdQuery, GetCoreAssetCustomTemplateByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetCustomTemplateRepository _CoreAssetCustomTemplateRepository;

        #endregion

        #region Ctor

        public GetCoreAssetCustomTemplateByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetCustomTemplateRepository CoreAssetCustomTemplateRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetCustomTemplateRepository = CoreAssetCustomTemplateRepository;
        }

        #endregion

        #region methods

        public async Task<GetCoreAssetCustomTemplateByIdDTO> Handle(GetCoreAssetCustomTemplateByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetCustomTemplateResponse = new GetCoreAssetCustomTemplateByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _CoreAssetCustomTemplateRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                CoreAssetCustomTemplateResponse = _mapper.Map<GetCoreAssetCustomTemplateByIdDTO>(response);
                return CoreAssetCustomTemplateResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
