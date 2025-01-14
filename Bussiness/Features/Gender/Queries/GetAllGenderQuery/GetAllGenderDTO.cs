namespace Bussiness.Features.Gender.Queries.GetAllGenderQuery
{
    public class GetAllGenderDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

        #endregion
    }
}
