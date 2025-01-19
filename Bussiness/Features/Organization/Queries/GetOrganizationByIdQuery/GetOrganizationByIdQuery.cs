using MediatR;

namespace Bussiness.Features.Organization.Queries.GetOrganizationByIdQuery
{
    public class GetOrganizationByIdQuery
        : IRequest<GetOrganizationByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
