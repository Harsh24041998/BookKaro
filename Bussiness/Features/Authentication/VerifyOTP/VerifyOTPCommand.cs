using MediatR;

namespace Bussiness.Features.Authentication.VerifyOTP
{
    public class VerifyOTPCommand : IRequest<VerifyOTPCommandDTO>
    {
        public string MobileNumber { get; set; } = string.Empty;
        public string OTP { get; set; } = string.Empty;
    }
}
