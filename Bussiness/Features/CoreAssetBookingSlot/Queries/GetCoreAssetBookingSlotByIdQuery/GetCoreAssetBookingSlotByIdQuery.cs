using MediatR;

namespace Bussiness.Features.CoreAssetBookingSlot.Queries.GetCoreAssetBookingSlotByIdQuery
{
    public class GetCoreAssetBookingSlotByIdQuery
         : IRequest<GetCoreAssetBookingSlotByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
