using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.CoreAssetTemplate.Commands.DeleteCoreAssetTemplateCommand
{
    public class DeleteCoreAssetTemplateHandler : IRequestHandler<DeleteCoreAssetTemplateCommand, DeleteCoreAssetTemplateCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetTemplateRepository _CoreAssetTemplateRepository;

        #endregion

        #region Ctor

        public DeleteCoreAssetTemplateHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetTemplateRepository CoreAssetTemplateRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetTemplateRepository = CoreAssetTemplateRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteCoreAssetTemplateCommandDTO> Handle(DeleteCoreAssetTemplateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteCoreAssetTemplateCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetTemplateDO = _mapper.Map<CoreAssetTemplateDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _CoreAssetTemplateRepository.Delete(convertToCoreAssetTemplateDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToCoreAssetTemplateDtO = _mapper.Map<DeleteCoreAssetTemplateCommandDTO>(result);
                return convertToCoreAssetTemplateDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
