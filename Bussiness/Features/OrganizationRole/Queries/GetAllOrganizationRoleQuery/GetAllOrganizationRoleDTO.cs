namespace Bussiness.Features.OrganizationRole.Queries.GetAllOrganizationRoleQuery
{
    public class GetAllOrganizationRoleDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; } = default;
        public Guid UserId { get; set; } = default;
        public Guid RoleId { get; set; } = default;


        #endregion
    }
}
