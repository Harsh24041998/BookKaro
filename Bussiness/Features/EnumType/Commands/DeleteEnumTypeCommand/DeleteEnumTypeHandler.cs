using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.EnumType.Commands.DeleteEnumTypeCommand
{
    public class DeleteEnumTypeHandler : IRequestHandler<DeleteEnumTypeCommand, DeleteEnumTypeCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEnumTypeRepository _EnumTypeRepository;

        #endregion

        #region Ctor

        public DeleteEnumTypeHandler(IUnitOfWork unitOfWork, IMapper mapper, IEnumTypeRepository EnumTypeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _EnumTypeRepository = EnumTypeRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteEnumTypeCommandDTO> Handle(DeleteEnumTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteEnumTypeCommandDTO();
                var requestModel = request.Id;
                var convertToEnumTypeDO = _mapper.Map<EnumTypeDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _EnumTypeRepository.Delete(convertToEnumTypeDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToEnumTypeDtO = _mapper.Map<DeleteEnumTypeCommandDTO>(result);
                return convertToEnumTypeDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
