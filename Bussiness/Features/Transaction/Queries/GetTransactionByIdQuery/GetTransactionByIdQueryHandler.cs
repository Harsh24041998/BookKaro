using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Transaction.Queries.GetTransactionByIdQuery
{
    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, GetTransactionByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _TransactionRepository;

        #endregion

        #region Ctor

        public GetTransactionByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ITransactionRepository TransactionRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _TransactionRepository = TransactionRepository;
        }

        #endregion

        #region methods

        public async Task<GetTransactionByIdDTO> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var TransactionResponse = new GetTransactionByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _TransactionRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                TransactionResponse = _mapper.Map<GetTransactionByIdDTO>(response);
                return TransactionResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
