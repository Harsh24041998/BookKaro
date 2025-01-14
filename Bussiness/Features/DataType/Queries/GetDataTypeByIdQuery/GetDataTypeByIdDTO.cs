namespace Bussiness.Features.DataType.Queries.GetDataTypeByIdQuery
{
    public class GetDataTypeByIdDTO
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
