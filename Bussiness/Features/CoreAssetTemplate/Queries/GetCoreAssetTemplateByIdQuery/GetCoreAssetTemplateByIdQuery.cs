using MediatR;

namespace Bussiness.Features.CoreAssetTemplate.Queries.GetCoreAssetTemplateByIdQuery
{
    public class GetCoreAssetTemplateByIdQuery
        : IRequest<GetCoreAssetTemplateByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
