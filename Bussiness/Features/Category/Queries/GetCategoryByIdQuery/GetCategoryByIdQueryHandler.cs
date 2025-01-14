using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Category.Queries.GetCategoryByIdQuery
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _CategoryRepository;

        #endregion

        #region Ctor

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository CategoryRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CategoryRepository = CategoryRepository;
        }

        #endregion

        #region methods

        public async Task<GetCategoryByIdDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var CategoryResponse = new GetCategoryByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _CategoryRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                CategoryResponse = _mapper.Map<GetCategoryByIdDTO>(response);
                return CategoryResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
