using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.EnumValue.Commands.DeleteEnumValueCommand
{
    public class DeleteEnumValueHandler : IRequestHandler<DeleteEnumValueCommand, DeleteEnumValueCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEnumValueRepository _EnumValueRepository;

        #endregion

        #region Ctor

        public DeleteEnumValueHandler(IUnitOfWork unitOfWork, IMapper mapper, IEnumValueRepository EnumValueRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _EnumValueRepository = EnumValueRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteEnumValueCommandDTO> Handle(DeleteEnumValueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteEnumValueCommandDTO();
                var requestModel = request.Id;
                var convertToEnumValueDO = _mapper.Map<EnumValueDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _EnumValueRepository.Delete(convertToEnumValueDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToEnumValueDtO = _mapper.Map<DeleteEnumValueCommandDTO>(result);
                return convertToEnumValueDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
