using MediatR;

namespace Bussiness.Features.EnumType.Queries.GetEnumTypeByIdQuery
{
    public class GetEnumTypeByIdQuery
        : IRequest<GetEnumTypeByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
