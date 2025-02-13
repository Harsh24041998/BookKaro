using MediatR;

namespace Bussiness.Features.CoreAssetBookingSlot.Queries.GetAllCoreAssetBookingSlotQuery
{
    public class GetAllCoreAssetBookingSlotQuery
         : IRequest<IEnumerable<GetAllCoreAssetBookingSlotQueryDTO>>
    {
    }
}
