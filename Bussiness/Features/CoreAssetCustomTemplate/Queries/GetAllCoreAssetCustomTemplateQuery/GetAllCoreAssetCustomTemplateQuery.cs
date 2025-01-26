using MediatR;

namespace Bussiness.Features.CoreAssetCustomTemplate.Queries.GetAllCoreAssetCustomTemplateQuery
{
    public class GetAllCoreAssetCustomTemplateQuery
         : IRequest<IEnumerable<GetAllCoreAssetCustomTemplateDTO>>
    {
    }
}
