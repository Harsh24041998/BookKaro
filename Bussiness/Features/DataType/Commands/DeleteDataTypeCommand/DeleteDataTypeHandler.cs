using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.DataType.Commands.DeleteDataTypeCommand
{
    public class DeleteDataTypeHandler : IRequestHandler<DeleteDataTypeCommand, DeleteDataTypeCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDataTypeRepository _DataTypeRepository;

        #endregion

        #region Ctor

        public DeleteDataTypeHandler(IUnitOfWork unitOfWork, IMapper mapper, IDataTypeRepository DataTypeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _DataTypeRepository = DataTypeRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteDataTypeCommandDTO> Handle(DeleteDataTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteDataTypeCommandDTO();
                var requestModel = request.Id;
                var convertToDataTypeDO = _mapper.Map<DataTypeDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _DataTypeRepository.Delete(convertToDataTypeDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToDataTypeDtO = _mapper.Map<DeleteDataTypeCommandDTO>(result);
                return convertToDataTypeDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
