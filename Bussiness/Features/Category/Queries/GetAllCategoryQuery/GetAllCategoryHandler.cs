using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Category.Queries.GetAllCategoryQuery
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<GetAllCategoryDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _CategoryRepository;

        #endregion

        #region Ctor

        public GetAllCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository CategoryRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CategoryRepository = CategoryRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllCategoryDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var Categorys = await _CategoryRepository.ReadAllAsync(null, cancellationToken);

                var CategoryDTOs = _mapper.Map<IEnumerable<GetAllCategoryDTO>>(Categorys);
                return CategoryDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
