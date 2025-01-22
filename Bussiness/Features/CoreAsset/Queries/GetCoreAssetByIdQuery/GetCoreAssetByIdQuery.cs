using MediatR;

namespace Bussiness.Features.CoreAsset.Queries.GetCoreAssetByIdQuery
{
    public class GetCoreAssetByIdQuery
        : IRequest<GetCoreAssetByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
