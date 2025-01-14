using MediatR;

namespace Bussiness.Features.Category.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public Guid IndustryId { get; set; } = default;
        public bool IsActive { get; set; } = false;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = default;

        #endregion
    }
}
