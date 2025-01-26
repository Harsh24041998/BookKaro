using MediatR;

namespace Bussiness.Features.CoreAssetTemplate.Commands.UpdateCoreAssetTemplateCommand
{
    public class UpdateCoreAssetTemplateCommand : IRequest<UpdateCoreAssetTemplateCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public Guid AssetId { get; set; } = default;
        public Guid DayEnumValueId { get; set; } = default;
        public TimeSpan StartTime { get; set; } = default;
        public TimeSpan EndTime { get; set; } = default;
        public int Rate { get; set; } = default;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = default;

        #endregion
    }
}
