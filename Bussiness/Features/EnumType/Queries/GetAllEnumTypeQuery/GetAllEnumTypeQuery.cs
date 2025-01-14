using MediatR;

namespace Bussiness.Features.EnumType.Queries.GetAllEnumTypeQuery
{
    public class GetAllEnumTypeQuery
         : IRequest<IEnumerable<GetAllEnumTypeDTO>>
    {
    }
}
