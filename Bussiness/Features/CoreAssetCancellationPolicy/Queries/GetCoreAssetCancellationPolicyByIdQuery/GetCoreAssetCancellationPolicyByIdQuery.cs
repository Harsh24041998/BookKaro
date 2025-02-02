using MediatR;

namespace Bussiness.Features.CoreAssetCancellationPolicy.Queries.GetCoreAssetCancellationPolicyByIdQuery
{
    public class GetCoreAssetCancellationPolicyByIdQuery
        : IRequest<GetCoreAssetCancellationPolicyByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
