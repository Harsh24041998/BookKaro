using MediatR;

namespace Bussiness.Features.DataType.Queries.GetAllDataTypeQuery
{
    public class GetAllDataTypeQuery
         : IRequest<IEnumerable<GetAllDataTypeDTO>>
    {
    }
}
