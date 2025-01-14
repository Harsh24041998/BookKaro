using MediatR;

namespace Bussiness.Features.Industry.Queries.GetAllIndustryQuery
{
    public class GetAllIndustryQuery
         : IRequest<IEnumerable<GetAllIndustryDTO>>
    {
    }
}
