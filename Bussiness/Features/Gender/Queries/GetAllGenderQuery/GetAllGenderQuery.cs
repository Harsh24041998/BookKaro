using MediatR;

namespace Bussiness.Features.Gender.Queries.GetAllGenderQuery
{
    public class GetAllGenderQuery
         : IRequest<IEnumerable<GetAllGenderDTO>>
    {
    }
}
