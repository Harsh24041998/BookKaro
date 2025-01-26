using MediatR;

namespace Bussiness.Features.CoreAssetCustomTemplate.Commands.CreateCoreAssetCustomTemplateCommand
{
    public class CreateCoreAssetCustomTemplateCommand : IRequest<CreateCoreAssetCustomTemplateCommandDTO>
    {
        #region Properties
        public Guid AssetId { get; set; } = default;
        public DateTime Date { get; set; } = default;
        public TimeSpan StartTime { get; set; } = default;
        public TimeSpan EndTime { get; set; } = default;
        public int Rate { get; set; } = default;

        #endregion
    }
}
