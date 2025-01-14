namespace Bussiness.Features.Gender.Queries.GetGenderByIdQuery
{
    public class GetGenderByIdDTO
    {
        #region Properties

        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        #endregion
    }
}
