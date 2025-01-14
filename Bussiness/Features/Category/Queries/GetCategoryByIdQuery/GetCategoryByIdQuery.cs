using MediatR;

namespace Bussiness.Features.Category.Queries.GetCategoryByIdQuery
{
    public class GetCategoryByIdQuery
        : IRequest<GetCategoryByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
