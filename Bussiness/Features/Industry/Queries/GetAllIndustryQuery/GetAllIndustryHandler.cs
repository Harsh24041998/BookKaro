using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Industry.Queries.GetAllIndustryQuery
{
    public class GetAllIndustryHandler : IRequestHandler<GetAllIndustryQuery, IEnumerable<GetAllIndustryDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIndustryRepository _IndustryRepository;

        #endregion

        #region Ctor

        public GetAllIndustryHandler(IUnitOfWork unitOfWork, IMapper mapper, IIndustryRepository IndustryRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _IndustryRepository = IndustryRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllIndustryDTO>> Handle(GetAllIndustryQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var Industrys = await _IndustryRepository.ReadAllAsync(null, cancellationToken);

                var IndustryDTOs = _mapper.Map<IEnumerable<GetAllIndustryDTO>>(Industrys);
                return IndustryDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
