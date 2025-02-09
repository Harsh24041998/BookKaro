using MediatR;

namespace Bussiness.Features.CoreAssetBooking.Queries.GetAllCoreAssetBookingQuery
{
    public class GetAllCoreAssetBookingQuery
         : IRequest<IEnumerable<GetAllCoreAssetBookingQueryDTO>>
    { 
    }
}
