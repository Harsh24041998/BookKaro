using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Address.Queries.GetAllAddressQuery
{
    public class GetAllAddressHandler : IRequestHandler<GetAllAddressQuery, IEnumerable<GetAllAddressDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAddressRepository _AddressRepository;

        #endregion

        #region Ctor

        public GetAllAddressHandler(IUnitOfWork unitOfWork, IMapper mapper, IAddressRepository AddressRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _AddressRepository = AddressRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllAddressDTO>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var Addresss = await _AddressRepository.ReadAllAsync(null, cancellationToken);

                var AddressDTOs = _mapper.Map<IEnumerable<GetAllAddressDTO>>(Addresss);
                return AddressDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
