using MediatR;

namespace Bussiness.Features.CoreAssetBookingCancellation.Queries.GetCoreAssetBookingCancellationByIdQuery
{
    public class GetCoreAssetBookingCancellationByIdQuery
         : IRequest<GetCoreAssetBookingCancellationByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
