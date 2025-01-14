using MediatR;

namespace Bussiness.Features.Category.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
