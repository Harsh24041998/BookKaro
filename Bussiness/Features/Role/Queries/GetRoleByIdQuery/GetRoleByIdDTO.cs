namespace Bussiness.Features.Role.Queries.GetRoleByIdQuery
{
    public class GetRoleByIdDTO
    {
        #region Properties

        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }

        #endregion
    }
}
