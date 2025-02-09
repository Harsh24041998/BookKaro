using MediatR;

namespace Bussiness.Features.CoreAssetBooking.Queries.GetCoreAssetBookingByIdQuery
{
    public class GetCoreAssetBookingByIdQuery
         : IRequest<GetCoreAssetBookingByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
