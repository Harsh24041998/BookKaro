using MediatR;

namespace Bussiness.Features.Category.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandDTO>
    {
        #region Properties
        public Guid IndustryId { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = default;

        #endregion
    }
}
