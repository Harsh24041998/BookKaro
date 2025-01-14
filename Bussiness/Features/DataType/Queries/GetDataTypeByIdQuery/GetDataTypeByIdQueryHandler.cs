using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.DataType.Queries.GetDataTypeByIdQuery
{
    public class GetDataTypeByIdQueryHandler : IRequestHandler<GetDataTypeByIdQuery, GetDataTypeByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDataTypeRepository _DataTypeRepository;

        #endregion

        #region Ctor

        public GetDataTypeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IDataTypeRepository DataTypeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _DataTypeRepository = DataTypeRepository;
        }

        #endregion

        #region methods

        public async Task<GetDataTypeByIdDTO> Handle(GetDataTypeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var DataTypeResponse = new GetDataTypeByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _DataTypeRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                DataTypeResponse = _mapper.Map<GetDataTypeByIdDTO>(response);
                return DataTypeResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
