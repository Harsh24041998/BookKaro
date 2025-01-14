using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.DataType.Queries.GetAllDataTypeByNameQuery
{
    public class GetAllDataTypeByNameQueryHandler : IRequestHandler<GetAllDataTypeByNameQuery, GetAllDataTypeByNameDTO>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDataTypeRepository _dataTypeRepository;

        #endregion

        #region Ctor

        public GetAllDataTypeByNameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IDataTypeRepository DataTypeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dataTypeRepository = DataTypeRepository;
        }

        #endregion

        #region methods

        public async Task<GetAllDataTypeByNameDTO> Handle(GetAllDataTypeByNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var BookingResponse = new GetAllDataTypeByNameDTO();
                string propertiesToInclude = "";
                var response = await _dataTypeRepository.GetAllDataTypeByName(propertiesToInclude, request.Name, cancellationToken);

                BookingResponse = _mapper.Map<GetAllDataTypeByNameDTO>(response);
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
