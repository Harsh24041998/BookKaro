using MediatR;

namespace Bussiness.Features.CoreAssetTemplate.Queries.GetAllCoreAssetTemplateQuery
{
    public class GetAllCoreAssetTemplateQuery
         : IRequest<IEnumerable<GetAllCoreAssetTemplateDTO>>
    {
    }
}
