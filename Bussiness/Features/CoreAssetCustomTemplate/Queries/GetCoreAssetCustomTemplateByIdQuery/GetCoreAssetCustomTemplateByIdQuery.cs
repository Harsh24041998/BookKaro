using MediatR;

namespace Bussiness.Features.CoreAssetCustomTemplate.Queries.GetCoreAssetCustomTemplateByIdQuery
{
    public class GetCoreAssetCustomTemplateByIdQuery
        : IRequest<GetCoreAssetCustomTemplateByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
