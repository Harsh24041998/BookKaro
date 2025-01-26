using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.CoreAssetCustomTemplate.Commands.DeleteCoreAssetCustomTemplateCommand
{
    public class DeleteCoreAssetCustomTemplateHandler : IRequestHandler<DeleteCoreAssetCustomTemplateCommand, DeleteCoreAssetCustomTemplateCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetCustomTemplateRepository _CoreAssetCustomTemplateRepository;

        #endregion

        #region Ctor

        public DeleteCoreAssetCustomTemplateHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetCustomTemplateRepository CoreAssetCustomTemplateRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetCustomTemplateRepository = CoreAssetCustomTemplateRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteCoreAssetCustomTemplateCommandDTO> Handle(DeleteCoreAssetCustomTemplateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteCoreAssetCustomTemplateCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetCustomTemplateDO = _mapper.Map<CoreAssetCustomTemplateDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _CoreAssetCustomTemplateRepository.Delete(convertToCoreAssetCustomTemplateDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToCoreAssetCustomTemplateDtO = _mapper.Map<DeleteCoreAssetCustomTemplateCommandDTO>(result);
                return convertToCoreAssetCustomTemplateDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
