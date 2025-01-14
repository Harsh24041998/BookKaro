using MediatR;

namespace Bussiness.Features.Authentication.SendOTP
{
    public class SendOTPCommand : IRequest<SendOTPCommandDTO>
    {
        public string MobileNumber { get; set; } = string.Empty;
    }
}
