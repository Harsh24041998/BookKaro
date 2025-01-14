using MediatR;

namespace Bussiness.Features.Industry.Queries.GetIndustryByIdQuery
{
    public class GetIndustryByIdQuery
        : IRequest<GetIndustryByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
