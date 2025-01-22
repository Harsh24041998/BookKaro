using MediatR;

namespace Bussiness.Features.CoreAsset.Commands.UpdateCoreAssetCommand
{
    public class UpdateCoreAssetCommand : IRequest<UpdateCoreAssetCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public Guid OrganizationID { get; set; }
        public Guid CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AssetNo { get; set; } = default;
        public int Priority { get; set; } = default;
        public int SlotInterval { get; set; } = default;
        public bool IsOnline { get; set; } = default;
        public bool IsActive { get; set; } = false;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = default;

        #endregion
    }
}
