using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.Industry.Commands.DeleteIndustryCommand
{
    public class DeleteIndustryHandler : IRequestHandler<DeleteIndustryCommand, DeleteIndustryCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIndustryRepository _IndustryRepository;

        #endregion

        #region Ctor

        public DeleteIndustryHandler(IUnitOfWork unitOfWork, IMapper mapper, IIndustryRepository IndustryRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _IndustryRepository = IndustryRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteIndustryCommandDTO> Handle(DeleteIndustryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteIndustryCommandDTO();
                var requestModel = request.Id;
                var convertToIndustryDO = _mapper.Map<IndustryDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _IndustryRepository.Delete(convertToIndustryDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToIndustryDtO = _mapper.Map<DeleteIndustryCommandDTO>(result);
                return convertToIndustryDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
