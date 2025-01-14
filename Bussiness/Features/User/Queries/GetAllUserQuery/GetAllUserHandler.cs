using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.User.Queries.GetAllUserQuery
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, IEnumerable<GetAllUserDTO>>
    {
        #region field

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _UserRepository;

        #endregion

        #region Ctor

        public GetAllUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository UserRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _UserRepository = UserRepository;
        }

        #endregion

        #region methods

        public async Task<IEnumerable<GetAllUserDTO>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string propertiesToInclude = "UserType,Gender";
                var Users = await _UserRepository.ReadAllAsync(propertiesToInclude, cancellationToken);

                var UserDTOs = _mapper.Map<IEnumerable<GetAllUserDTO>>(Users);
                return UserDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
