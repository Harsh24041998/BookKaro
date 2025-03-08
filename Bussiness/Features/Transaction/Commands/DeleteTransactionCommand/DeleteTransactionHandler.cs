using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.Transaction.Commands.DeleteTransactionCommand
{
    public class DeleteTransactionHandler : IRequestHandler<DeleteTransactionCommand, DeleteTransactionCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _TransactionRepository;

        #endregion

        #region Ctor

        public DeleteTransactionHandler(IUnitOfWork unitOfWork, IMapper mapper, ITransactionRepository TransactionRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _TransactionRepository = TransactionRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteTransactionCommandDTO> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteTransactionCommandDTO();
                var requestModel = request.Id;
                var convertToTransactionDO = _mapper.Map<TransactionDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _TransactionRepository.Delete(convertToTransactionDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToTransactionDtO = _mapper.Map<DeleteTransactionCommandDTO>(result);
                return convertToTransactionDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
