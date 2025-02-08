namespace Bussiness.Features.Address.Queries.GetAllAddressQuery
{
    public class GetAllAddressDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Pincode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public Guid OrganizationId { get; set; } = default;
        public string IOrganizationName { get; set; } = string.Empty;


        #endregion
    }
}
