using MediatR;

namespace Bussiness.Features.CoreAssetBookingCancellation.Queries.GetAllCoreAssetBookingCancellationQuery
{
    public class GetAllCoreAssetBookingCancellationQuery
         : IRequest<IEnumerable<GetAllCoreAssetBookingCancellationQueryDTO>>
    {
    }
}
