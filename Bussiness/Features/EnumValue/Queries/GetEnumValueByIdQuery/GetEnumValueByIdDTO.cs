namespace Bussiness.Features.EnumValue.Queries.GetEnumValueByIdQuery
{
    public class GetEnumValueByIdDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid EnumTypeId { get; set; } = default;
        public string EnumTypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

        #endregion
    }
}
