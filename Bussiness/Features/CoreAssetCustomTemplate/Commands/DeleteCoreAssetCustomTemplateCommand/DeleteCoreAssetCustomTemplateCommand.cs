using MediatR;

namespace Bussiness.Features.CoreAssetCustomTemplate.Commands.DeleteCoreAssetCustomTemplateCommand
{
    public class DeleteCoreAssetCustomTemplateCommand : IRequest<DeleteCoreAssetCustomTemplateCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
