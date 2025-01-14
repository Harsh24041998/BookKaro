using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.EnumValue.Queries.GetAllEnumValueQuery
{
    public class GetAllEnumValueHandler : IRequestHandler<GetAllEnumValueQuery, IEnumerable<GetAllEnumValueDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEnumValueRepository _EnumValueRepository;

        #endregion

        #region Ctor

        public GetAllEnumValueHandler(IUnitOfWork unitOfWork, IMapper mapper, IEnumValueRepository EnumValueRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _EnumValueRepository = EnumValueRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllEnumValueDTO>> Handle(GetAllEnumValueQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var EnumValues = await _EnumValueRepository.ReadAllAsync(null, cancellationToken);

                var EnumValueDTOs = _mapper.Map<IEnumerable<GetAllEnumValueDTO>>(EnumValues);
                return EnumValueDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
