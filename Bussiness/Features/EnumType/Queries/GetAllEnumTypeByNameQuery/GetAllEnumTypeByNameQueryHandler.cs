using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.EnumType.Queries.GetAllEnumTypeByNameQuery
{
    public class GetAllEnumTypeByNameQueryHandler : IRequestHandler<GetAllEnumTypeByNameQuery, GetAllEnumTypeByNameDTO>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEnumTypeRepository _EnumTypeRepository;

        #endregion

        #region Ctor

        public GetAllEnumTypeByNameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IEnumTypeRepository EnumTypeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _EnumTypeRepository = EnumTypeRepository;
        }

        #endregion

        #region methods

        public async Task<GetAllEnumTypeByNameDTO> Handle(GetAllEnumTypeByNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var BookingResponse = new GetAllEnumTypeByNameDTO();
                string propertiesToInclude = "";
                var response = await _EnumTypeRepository.GetAllEnumTypeByName(propertiesToInclude, request.Name, cancellationToken);

                BookingResponse = _mapper.Map<GetAllEnumTypeByNameDTO>(response);
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
