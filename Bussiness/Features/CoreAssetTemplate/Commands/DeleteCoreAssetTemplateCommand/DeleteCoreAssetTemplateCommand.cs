using MediatR;

namespace Bussiness.Features.CoreAssetTemplate.Commands.DeleteCoreAssetTemplateCommand
{
    public class DeleteCoreAssetTemplateCommand : IRequest<DeleteCoreAssetTemplateCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
