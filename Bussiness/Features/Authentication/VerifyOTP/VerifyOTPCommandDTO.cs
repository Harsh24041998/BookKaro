namespace Bussiness.Features.Authentication.VerifyOTP
{
    public class VerifyOTPCommandDTO
    {
        #region properties

        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public Guid Id { get; set; }
        public Guid UserTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public DateTime DOB { get; set; } = default;
        public bool IsActive { get; set; } = default;
        public string JWTToken { get; set; } = string.Empty;
        #endregion
    }
}
