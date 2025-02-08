using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Address.Queries.GetAddressByIdQuery
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, GetAddressByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAddressRepository _AddressRepository;

        #endregion

        #region Ctor

        public GetAddressByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IAddressRepository AddressRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _AddressRepository = AddressRepository;
        }

        #endregion

        #region methods

        public async Task<GetAddressByIdDTO> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var AddressResponse = new GetAddressByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _AddressRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                AddressResponse = _mapper.Map<GetAddressByIdDTO>(response);
                return AddressResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
