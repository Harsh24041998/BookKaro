using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.User.Commands.DeleteUserCommand
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _UserRepository;

        #endregion

        #region Ctor

        public DeleteUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository UserRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _UserRepository = UserRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteUserCommandDTO> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteUserCommandDTO();
                var requestModel = request.Id;
                var convertToUserDO = _mapper.Map<UserDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _UserRepository.Delete(convertToUserDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToUserDtO = _mapper.Map<DeleteUserCommandDTO>(result);
                return convertToUserDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
