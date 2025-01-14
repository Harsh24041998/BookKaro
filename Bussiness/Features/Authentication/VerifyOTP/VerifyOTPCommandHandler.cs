using Bussiness.Contracts.Services;
using Bussiness.Contracts;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Bussiness.DomainObjects;
using System.IdentityModel.Tokens.Jwt;
using Bussiness.Contracts.Repositories;

namespace Bussiness.Features.Authentication.VerifyOTP
{
    public class VerifyOTPCommandHandler : IRequestHandler<VerifyOTPCommand, VerifyOTPCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IOTPService _otpOperation;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        #endregion

        #region Ctor

        public VerifyOTPCommandHandler(IUnitOfWork unitOfWork, IOTPService otpOperation, IConfiguration configuration, IUserRepository userRepository, IAuthService authService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _otpOperation = otpOperation;
            _configuration = configuration;
            _userRepository = userRepository;
            _authService = authService;
        }

        #endregion

        #region methods

        public async Task<VerifyOTPCommandDTO> Handle(VerifyOTPCommand request, CancellationToken cancellationToken)
        {

            try
            {
                // Call the VerifyOtpRequestAsync method to get the response
                var jsonResponse = await _otpOperation.VerifyOtpRequestAsync(request.MobileNumber, request.OTP);

                // Deserialize the JSON response
                var otpResponse = JsonSerializer.Deserialize<JsonElement>(jsonResponse);

                // Create the DTO from the JSON properties
                var resultDto = new VerifyOTPCommandDTO
                {
                    Message = otpResponse.GetProperty("message").GetString(), // Access request_id
                    Type = otpResponse.GetProperty("type").GetString(), // Access type
                    Code = "200"
                };

                if (resultDto.Type == "success")
                {
                    string propertiesToInclude = "UserType,Gender";
                    var userDetail = (await _userRepository.GetUserbyMobileNumber(propertiesToInclude, request.MobileNumber, cancellationToken));
                    if (userDetail != null)
                    {
                        VerifyOTPCommandDTO loginDetails = new VerifyOTPCommandDTO();
                        loginDetails.Message = resultDto.Message;
                        loginDetails.Type = resultDto.Type;
                        loginDetails.Code = resultDto.Code;
                        loginDetails.Name = userDetail.Name;
                        loginDetails.EmailId = userDetail.EmailId;
                        loginDetails.Id = userDetail.Id;
                        loginDetails.MobileNumber = userDetail.MobileNumber;
                        loginDetails.JWTToken = CreateToken(userDetail);

                        return loginDetails;
                    }
                }
                // Return the mapped DTO
                return resultDto;
            }
            catch (Exception ex)
            {
                // Handle or log the exception as necessary
                throw new Exception("An error occurred while Verifying OTP.", ex);
            }
        }
        public string CreateToken(UserDO user)
        {
            var claims = new Claim[]
            {
            new(JwtRegisteredClaimNames.Name,user.Name),
            new(JwtRegisteredClaimNames.Sid,user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email,user.EmailId),
            new(JwtRegisteredClaimNames.PhoneNumber,user.MobileNumber),
            new(JwtRegisteredClaimNames.NameId,user.GenderId.ToString()),
            };

            string tokenValue = _authService.GenerateToken(claims);

            return tokenValue;
        }
        #endregion
    }
}
