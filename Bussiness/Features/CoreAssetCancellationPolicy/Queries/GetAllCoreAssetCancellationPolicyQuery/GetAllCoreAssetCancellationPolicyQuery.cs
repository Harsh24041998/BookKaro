using MediatR;

namespace Bussiness.Features.CoreAssetCancellationPolicy.Queries.GetAllCoreAssetCancellationPolicyQuery
{
    public class GetAllCoreAssetCancellationPolicyQuery
         : IRequest<IEnumerable<GetAllCoreAssetCancellationPolicyDTO>>
    {
    }
}
