using MediatR;

namespace Bussiness.Features.CoreAsset.Commands.DeleteCoreAssetCommand
{
    public class DeleteCoreAssetCommand : IRequest<DeleteCoreAssetCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
