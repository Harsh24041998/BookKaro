using MediatR;

namespace Bussiness.Features.User.Queries.GetUserByIdQuery
{
    public class GetUserByIdQuery
        : IRequest<GetUserByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
