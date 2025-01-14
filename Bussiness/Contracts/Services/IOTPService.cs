namespace Bussiness.Contracts.Services
{
    public interface IOTPService
    {
        public Task<string> SendOtpRequestAsync(string MobileNumber);
        public Task<string> VerifyOtpRequestAsync(string MobileNumber, string OTP);
    }
}
