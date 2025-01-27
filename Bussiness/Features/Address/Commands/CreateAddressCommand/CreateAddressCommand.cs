using MediatR;

namespace Bussiness.Features.Address.Commands.CreateAddressCommand
{
    public class CreateAddressCommand : IRequest<CreateAddressCommandDTO>
    {
        #region Properties
        public Guid OrganizationId { get; set; } = default; 
        public string Address { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Pincode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        #endregion
    }
}
