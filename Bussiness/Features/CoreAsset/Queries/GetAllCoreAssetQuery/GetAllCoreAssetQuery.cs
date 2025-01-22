using MediatR;

namespace Bussiness.Features.CoreAsset.Queries.GetAllCoreAssetQuery
{
    public class GetAllCoreAssetQuery
         : IRequest<IEnumerable<GetAllCoreAssetDTO>>
    {
    }
}
