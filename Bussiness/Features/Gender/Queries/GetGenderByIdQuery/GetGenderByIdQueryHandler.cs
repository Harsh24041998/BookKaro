using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Gender.Queries.GetGenderByIdQuery
{
    public class GetGenderByIdQueryHandler : IRequestHandler<GetGenderByIdQuery, GetGenderByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenderRepository _GenderRepository;

        #endregion

        #region Ctor

        public GetGenderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IGenderRepository GenderRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _GenderRepository = GenderRepository;
        }

        #endregion

        #region methods

        public async Task<GetGenderByIdDTO> Handle(GetGenderByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var GenderResponse = new GetGenderByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _GenderRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                GenderResponse = _mapper.Map<GetGenderByIdDTO>(response);
                return GenderResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
