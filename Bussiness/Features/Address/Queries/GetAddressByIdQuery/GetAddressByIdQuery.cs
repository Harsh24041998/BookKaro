using MediatR;

namespace Bussiness.Features.Address.Queries.GetAddressByIdQuery
{
    public class GetAddressByIdQuery
        : IRequest<GetAddressByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
