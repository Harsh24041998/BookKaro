using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.User.Commands.UpdateUserCommand
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _UserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository UserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _UserRepository = UserRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateUserCommandDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserResponse = new UpdateUserCommandDTO();
                var requestModel = request.Id;
                var convertToUserDO = _mapper.Map<UserDO>(request);

                string propertiesToInclude = "";
                var response = await _UserRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
                if (response != null)
                {

                    var userClaims = _httpContextAccessor.HttpContext.User.Claims;
                    //var firstName = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value;
                    //var LastName = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Nickname)?.Value;
                    //var empCode = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;
                    //var email = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email || c.Type == ClaimTypes.Email)?.Value;
                    //var phoneNumber = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.PhoneNumber)?.Value;
                    //var userId = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId || c.Type == ClaimTypes.NameIdentifier)?.Value;



                    response.Name = request.Name == response.Name ? response.Name : request.Name;
                    response.EmailId = request.EmailId == response.EmailId ? response.EmailId : request.EmailId;
                    response.MobileNumber = request.MobileNumber == response.MobileNumber ? response.MobileNumber : request.MobileNumber;
                    response.GenderId = request.GenderId == response.GenderId ? response.GenderId : request.GenderId;
                    response.OTPAttempts = request.OTPAttempts == response.OTPAttempts ? response.OTPAttempts : request.OTPAttempts;
                    response.IsActive = request.IsActive == response.IsActive ? response.IsActive : request.IsActive;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = "Harsh";//empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _UserRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToUserDtO = _mapper.Map<UpdateUserCommandDTO>(result);
                    return convertToUserDtO;
                }
                else
                {
                    throw new Exception(message: "No data found against provided Id");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
