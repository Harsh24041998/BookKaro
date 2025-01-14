using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Industry.Queries.GetAllIndustryByNameQuery
{
    public class GetAllIndustryByNameQueryHandler : IRequestHandler<GetAllIndustryByNameQuery, GetAllIndustryByNameDTO>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIndustryRepository _IndustryRepository;

        #endregion

        #region Ctor

        public GetAllIndustryByNameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IIndustryRepository IndustryRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _IndustryRepository = IndustryRepository;
        }

        #endregion

        #region methods

        public async Task<GetAllIndustryByNameDTO> Handle(GetAllIndustryByNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var BookingResponse = new GetAllIndustryByNameDTO();
                string propertiesToInclude = "";
                var response = await _IndustryRepository.GetAllIndustryByName(propertiesToInclude, request.Name, cancellationToken);

                BookingResponse = _mapper.Map<GetAllIndustryByNameDTO>(response);
                return BookingResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
