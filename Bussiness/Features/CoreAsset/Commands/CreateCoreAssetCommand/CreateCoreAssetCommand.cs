using MediatR;

namespace Bussiness.Features.CoreAsset.Commands.CreateCoreAssetCommand
{
    public class CreateCoreAssetCommand : IRequest<CreateCoreAssetCommandDTO>
    {
        #region Properties
        public Guid OrganizationID { get; set; }
        public Guid CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AssetNo { get; set; } = default;
        public int Priority { get; set; } = default;
        public int SlotInterval { get; set; } = default;
        public bool IsOnline { get; set; } = default;
        public bool IsActive { get; set; } = default;

        #endregion
    }
}
