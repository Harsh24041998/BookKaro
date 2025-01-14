using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Gender.Queries.GetAllGenderQuery
{
    public class GetAllGenderHandler : IRequestHandler<GetAllGenderQuery, IEnumerable<GetAllGenderDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenderRepository _GenderRepository;

        #endregion

        #region Ctor

        public GetAllGenderHandler(IUnitOfWork unitOfWork, IMapper mapper, IGenderRepository GenderRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _GenderRepository = GenderRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllGenderDTO>> Handle(GetAllGenderQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string propertiesToInclude = "";
                var Genders = await _GenderRepository.ReadAllAsync(propertiesToInclude, cancellationToken);

                var GenderDTOs = _mapper.Map<IEnumerable<GetAllGenderDTO>>(Genders);
                return GenderDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
