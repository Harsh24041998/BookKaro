using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.EnumType.Queries.GetEnumTypeByIdQuery
{
    public class GetEnumTypeByIdQueryHandler : IRequestHandler<GetEnumTypeByIdQuery, GetEnumTypeByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEnumTypeRepository _EnumTypeRepository;

        #endregion

        #region Ctor

        public GetEnumTypeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IEnumTypeRepository EnumTypeRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _EnumTypeRepository = EnumTypeRepository;
        }

        #endregion

        #region methods

        public async Task<GetEnumTypeByIdDTO> Handle(GetEnumTypeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var EnumTypeResponse = new GetEnumTypeByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _EnumTypeRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                EnumTypeResponse = _mapper.Map<GetEnumTypeByIdDTO>(response);
                return EnumTypeResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
