using MediatR;

namespace Bussiness.Features.User.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<UpdateUserCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public Guid GenderId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public int OTPAttempts { get; set; } = default;
        public bool IsActive { get; set; } = default;

        #endregion
    }
}
