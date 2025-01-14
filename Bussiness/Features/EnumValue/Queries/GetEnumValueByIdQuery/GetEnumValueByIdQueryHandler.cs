using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.EnumValue.Queries.GetEnumValueByIdQuery
{
    public class GetEnumValueByIdQueryHandler : IRequestHandler<GetEnumValueByIdQuery, GetEnumValueByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEnumValueRepository _EnumValueRepository;

        #endregion

        #region Ctor

        public GetEnumValueByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IEnumValueRepository EnumValueRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _EnumValueRepository = EnumValueRepository;
        }

        #endregion

        #region methods

        public async Task<GetEnumValueByIdDTO> Handle(GetEnumValueByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var EnumValueResponse = new GetEnumValueByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _EnumValueRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                EnumValueResponse = _mapper.Map<GetEnumValueByIdDTO>(response);
                return EnumValueResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
