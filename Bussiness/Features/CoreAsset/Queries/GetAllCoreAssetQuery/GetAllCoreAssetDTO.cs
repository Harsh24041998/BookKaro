namespace Bussiness.Features.CoreAsset.Queries.GetAllCoreAssetQuery
{
    public class GetAllCoreAssetDTO
    {
        #region Column Properties
        public Guid OrganizationID { get; set; }
        public Guid CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AssetNo { get; set; } = default;
        public int Priority { get; set; } = default;
        public int SlotInterval { get; set; } = default;
        public bool IsOnline { get; set; } = default;
        public bool IsActive { get; set; } = default;
        public string OrganizationName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;

        #endregion
    }
}
