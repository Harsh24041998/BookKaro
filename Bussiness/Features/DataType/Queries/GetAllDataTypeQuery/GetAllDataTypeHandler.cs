using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.DataType.Queries.GetAllDataTypeQuery
{
    public class GetAllDataTypeHandler : IRequestHandler<GetAllDataTypeQuery, IEnumerable<GetAllDataTypeDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDataTypeRepository _DataTypeRepository;

        #endregion

        #region Ctor

        public GetAllDataTypeHandler(IUnitOfWork unitOfWork, IMapper mapper, IDataTypeRepository DataTypeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _DataTypeRepository = DataTypeRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllDataTypeDTO>> Handle(GetAllDataTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var DataTypes = await _DataTypeRepository.ReadAllAsync(null, cancellationToken);

                var DataTypeDTOs = _mapper.Map<IEnumerable<GetAllDataTypeDTO>>(DataTypes);
                return DataTypeDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
