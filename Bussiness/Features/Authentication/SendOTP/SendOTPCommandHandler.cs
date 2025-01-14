using Bussiness.Contracts.Services;
using Bussiness.Contracts;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Bussiness.Features.Authentication.SendOTP
{
    public class SendOTPCommandHandler : IRequestHandler<SendOTPCommand, SendOTPCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IOTPService _otpOperation;
        private readonly IConfiguration _configuration;

        #endregion

        #region Ctor

        public SendOTPCommandHandler(IUnitOfWork unitOfWork, IOTPService otpOperation, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _otpOperation = otpOperation;
            _configuration = configuration;
        }

        #endregion

        #region methods

        public async Task<SendOTPCommandDTO> Handle(SendOTPCommand request, CancellationToken cancellationToken)
        {

            try
            {
                // Call the SendOtpRequestAsync method to get the response
                var jsonResponse = await _otpOperation.SendOtpRequestAsync(request.MobileNumber);

                // Deserialize the JSON response
                var otpResponse = JsonSerializer.Deserialize<JsonElement>(jsonResponse);

                // Create the DTO from the JSON properties
                var resultDto = new SendOTPCommandDTO
                {
                    RequestID = otpResponse.GetProperty("request_id").GetString(), // Access request_id
                    Type = otpResponse.GetProperty("type").GetString() // Access type
                };

                // Return the mapped DTO
                return resultDto;
            }
            catch (Exception ex)
            {
                // Handle or log the exception as necessary
                throw new Exception("An error occurred while sending OTP.", ex);
            }
        }

        #endregion
    }
}
