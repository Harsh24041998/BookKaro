using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.Category.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _CategoryRepository;

        #endregion

        #region Ctor

        public DeleteCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository CategoryRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CategoryRepository = CategoryRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteCategoryCommandDTO> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteCategoryCommandDTO();
                var requestModel = request.Id;
                var convertToCategoryDO = _mapper.Map<CategoryDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _CategoryRepository.Delete(convertToCategoryDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToCategoryDtO = _mapper.Map<DeleteCategoryCommandDTO>(result);
                return convertToCategoryDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
