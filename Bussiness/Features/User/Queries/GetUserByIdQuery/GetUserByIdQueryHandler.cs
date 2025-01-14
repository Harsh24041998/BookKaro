using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.User.Queries.GetUserByIdQuery
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _UserRepository;

        #endregion

        #region Ctor

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository UserRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _UserRepository = UserRepository;
        }

        #endregion

        #region methods

        public async Task<GetUserByIdDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var UserResponse = new GetUserByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _UserRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                UserResponse = _mapper.Map<GetUserByIdDTO>(response);
                return UserResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
