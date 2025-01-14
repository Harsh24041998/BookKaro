using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.User.Queries.GetUserByMobileNumberQuery
{
    public class GetUserByMobileNumberQueryHandler : IRequestHandler<GetUserByMobileNumberQuery, GetUserByMobileNumberDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _UserRepository;

        #endregion

        #region Ctor

        public GetUserByMobileNumberQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository UserRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _UserRepository = UserRepository;
        }

        #endregion

        #region methods

        public async Task<GetUserByMobileNumberDTO> Handle(GetUserByMobileNumberQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var UserResponse = new GetUserByMobileNumberDTO();
                var requestModel = request.MobileNumber;

                string propertiesToInclude = "UserType,Gender";
                var response = await _UserRepository.GetUserbyMobileNumber( propertiesToInclude, request.MobileNumber, cancellationToken);

                UserResponse = _mapper.Map<GetUserByMobileNumberDTO>(response);
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
