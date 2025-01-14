namespace Bussiness.Contracts.Services
{
    public interface ISMSService
    {
        public Task<string> SendFlowRequestAsync(string MobileNumber, string OTP);
    }
}
