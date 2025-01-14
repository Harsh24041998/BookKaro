using MediatR;

namespace Bussiness.Features.EnumValue.Queries.GetEnumValueByIdQuery
{
    public class GetEnumValueByIdQuery
        : IRequest<GetEnumValueByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
