namespace Bussiness.Features.CoreAssetTemplate.Queries.GetCoreAssetTemplateByIdQuery
{
    public class GetCoreAssetTemplateByIdDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid AssetId { get; set; } = default;
        public Guid DayEnumValueId { get; set; } = default;
        public TimeSpan StartTime { get; set; } = default;
        public TimeSpan EndTime { get; set; } = default;
        public int Rate { get; set; } = default;
        public string AssetName { get; set; } = string.Empty;
        public string DayEnumValue { get; set; } = string.Empty;

        #endregion
    }
}
