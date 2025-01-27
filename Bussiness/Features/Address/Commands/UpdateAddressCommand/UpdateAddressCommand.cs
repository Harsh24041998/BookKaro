using MediatR;

namespace Bussiness.Features.Address.Commands.UpdateAddressCommand
{
    public class UpdateAddressCommand : IRequest<UpdateAddressCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; } = default;
        public string Address { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Pincode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = default;

        #endregion
    }
}
