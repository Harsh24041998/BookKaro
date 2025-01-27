using MediatR;

namespace Bussiness.Features.Address.Queries.GetAllAddressQuery
{
    public class GetAllAddressQuery
         : IRequest<IEnumerable<GetAllAddressDTO>>
    {
    }
}
