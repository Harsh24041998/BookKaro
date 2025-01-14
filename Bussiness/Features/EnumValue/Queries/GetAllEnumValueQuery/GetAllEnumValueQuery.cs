using MediatR;

namespace Bussiness.Features.EnumValue.Queries.GetAllEnumValueQuery
{
    public class GetAllEnumValueQuery
         : IRequest<IEnumerable<GetAllEnumValueDTO>>
    {
    }
}
