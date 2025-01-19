namespace Bussiness.Features.Organization.Queries.GetOrganizationByIdQuery
{
    public class GetOrganizationByIdDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid IndustryId { get; set; } = default;
        public string IndustryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsMobile { get; set; } = false;
        public bool IsActive { get; set; } = false;

        #endregion
    }
}
