using MediatR;

namespace Bussiness.Features.Industry.Queries.GetAllIndustryByNameQuery
{
    public class GetAllIndustryByNameQuery
         : IRequest<GetAllIndustryByNameDTO>
    {
        #region properties

        public string? Name { get; set; }

        #endregion
    }
}
