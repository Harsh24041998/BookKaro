using MediatR;

namespace Bussiness.Features.Category.Queries.GetAllCategoryQuery
{
    public class GetAllCategoryQuery
         : IRequest<IEnumerable<GetAllCategoryDTO>>
    {
    }
}
