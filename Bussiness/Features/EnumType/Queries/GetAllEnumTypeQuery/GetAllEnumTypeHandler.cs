using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.EnumType.Queries.GetAllEnumTypeQuery
{
    public class GetAllEnumTypeHandler : IRequestHandler<GetAllEnumTypeQuery, IEnumerable<GetAllEnumTypeDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEnumTypeRepository _EnumTypeRepository;

        #endregion

        #region Ctor

        public GetAllEnumTypeHandler(IUnitOfWork unitOfWork, IMapper mapper, IEnumTypeRepository EnumTypeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _EnumTypeRepository = EnumTypeRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllEnumTypeDTO>> Handle(GetAllEnumTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var EnumTypes = await _EnumTypeRepository.ReadAllAsync(null, cancellationToken);

                var EnumTypeDTOs = _mapper.Map<IEnumerable<GetAllEnumTypeDTO>>(EnumTypes);
                return EnumTypeDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
