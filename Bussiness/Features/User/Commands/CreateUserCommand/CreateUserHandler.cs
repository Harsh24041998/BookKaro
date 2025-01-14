using AutoMapper;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using Bussiness.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bussiness.Features.User.Commands.CreateUserCommand
{
    public class CreateUserHandler
        : IRequestHandler<CreateUserCommand, CreateUserCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods

        public async Task<CreateUserCommandDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                UserDO User = _mapper.Map<UserDO>(request);

                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                string UserCodeString = SequenceCodes.User.ToString();
                //                User.Code = "";// await _unitOfWork.SequenceRepository.GenerateNext(UserCodeString, cancellationToken);

                var userClaims = _httpContextAccessor.HttpContext.User.Claims;
                //var firstName = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value;
                //var LastName = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Nickname)?.Value;
                //var empCode = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;
                //var email = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email || c.Type == ClaimTypes.Email)?.Value;
                //var phoneNumber = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.PhoneNumber)?.Value;
                //var userId = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId || c.Type == ClaimTypes.NameIdentifier)?.Value;


                User.CreatedBy = "Harsh";//empCode.ToString();

                var result = await _unitOfWork.UserRepository.Create(User, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return _mapper.Map<CreateUserCommandDTO>(result);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);

                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
