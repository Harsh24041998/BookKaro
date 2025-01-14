using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.Gender.Commands.DeleteGenderCommand
{
    public class DeleteGenderHandler : IRequestHandler<DeleteGenderCommand, DeleteGenderCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenderRepository _GenderRepository;

        #endregion

        #region Ctor

        public DeleteGenderHandler(IUnitOfWork unitOfWork, IMapper mapper, IGenderRepository GenderRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _GenderRepository = GenderRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteGenderCommandDTO> Handle(DeleteGenderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteGenderCommandDTO();
                var requestModel = request.Id;
                var convertToGenderDO = _mapper.Map<GenderDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _GenderRepository.Delete(convertToGenderDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToGenderDtO = _mapper.Map<DeleteGenderCommandDTO>(result);
                return convertToGenderDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
