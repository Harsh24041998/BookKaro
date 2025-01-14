namespace Bussiness.Features.Authentication.SendOTP
{
    public class SendOTPCommandDTO
    {
        #region properties

        public string RequestID { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        
        #endregion
    }
}
