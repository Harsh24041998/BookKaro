using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.CoreAssetTemplate.Queries.GetCoreAssetTemplateByIdQuery
{
    public class GetCoreAssetTemplateByIdQueryHandler : IRequestHandler<GetCoreAssetTemplateByIdQuery, GetCoreAssetTemplateByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetTemplateRepository _CoreAssetTemplateRepository;

        #endregion

        #region Ctor

        public GetCoreAssetTemplateByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetTemplateRepository CoreAssetTemplateRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetTemplateRepository = CoreAssetTemplateRepository;
        }

        #endregion

        #region methods

        public async Task<GetCoreAssetTemplateByIdDTO> Handle(GetCoreAssetTemplateByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetTemplateResponse = new GetCoreAssetTemplateByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _CoreAssetTemplateRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                CoreAssetTemplateResponse = _mapper.Map<GetCoreAssetTemplateByIdDTO>(response);
                return CoreAssetTemplateResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
