using MediatR;

namespace Bussiness.Features.CoreAssetTemplate.Commands.CreateCoreAssetTemplateCommand
{
    public class CreateCoreAssetTemplateCommand : IRequest<CreateCoreAssetTemplateCommandDTO>
    {
        #region Properties
        public Guid AssetId { get; set; } = default;
        public Guid DayEnumValueId { get; set; } = default;
        public TimeSpan StartTime { get; set; } = default;
        public TimeSpan EndTime { get; set; } = default;
        public int Rate { get; set; } = default;

        #endregion
    }
}
