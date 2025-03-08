using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Transaction.Queries.GetAllTransactionQuery
{
    public class GetAllTransactionHandler : IRequestHandler<GetAllTransactionQuery, IEnumerable<GetAllTransactionDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _TransactionRepository;

        #endregion

        #region Ctor

        public GetAllTransactionHandler(IUnitOfWork unitOfWork, IMapper mapper, ITransactionRepository TransactionRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _TransactionRepository = TransactionRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllTransactionDTO>> Handle(GetAllTransactionQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var Transactions = await _TransactionRepository.ReadAllAsync(null, cancellationToken);

                var TransactionDTOs = _mapper.Map<IEnumerable<GetAllTransactionDTO>>(Transactions);
                return TransactionDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
