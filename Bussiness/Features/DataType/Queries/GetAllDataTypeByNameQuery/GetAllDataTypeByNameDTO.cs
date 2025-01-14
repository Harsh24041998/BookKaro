namespace Bussiness.Features.DataType.Queries.GetAllDataTypeByNameQuery
{
    public class GetAllDataTypeByNameDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

        #endregion
    }
}
