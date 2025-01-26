using MediatR;

namespace Bussiness.Features.CoreAssetCustomTemplate.Commands.UpdateCoreAssetCustomTemplateCommand
{
    public class UpdateCoreAssetCustomTemplateCommand : IRequest<UpdateCoreAssetCustomTemplateCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public Guid AssetId { get; set; } = default;
        public DateTime Date { get; set; } = default;
        public TimeSpan StartTime { get; set; } = default;
        public TimeSpan EndTime { get; set; } = default;
        public int Rate { get; set; } = default;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = default;

        #endregion
    }
}
