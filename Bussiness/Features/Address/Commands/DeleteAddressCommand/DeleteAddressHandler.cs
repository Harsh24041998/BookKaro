using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.Address.Commands.DeleteAddressCommand
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand, DeleteAddressCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAddressRepository _AddressRepository;

        #endregion

        #region Ctor

        public DeleteAddressHandler(IUnitOfWork unitOfWork, IMapper mapper, IAddressRepository AddressRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _AddressRepository = AddressRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteAddressCommandDTO> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteAddressCommandDTO();
                var requestModel = request.Id;
                var convertToAddressDO = _mapper.Map<AddressDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _AddressRepository.Delete(convertToAddressDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToAddressDtO = _mapper.Map<DeleteAddressCommandDTO>(result);
                return convertToAddressDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
