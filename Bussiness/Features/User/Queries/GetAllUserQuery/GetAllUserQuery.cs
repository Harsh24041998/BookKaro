using Bussiness.Features.Gender.Queries.GetAllGenderQuery;
using MediatR;

namespace Bussiness.Features.User.Queries.GetAllUserQuery
{
    public class GetAllUserQuery
         : IRequest<IEnumerable<GetAllUserDTO>>
    {
    }
}
