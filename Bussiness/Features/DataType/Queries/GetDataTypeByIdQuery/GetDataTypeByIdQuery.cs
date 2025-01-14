using MediatR;

namespace Bussiness.Features.DataType.Queries.GetDataTypeByIdQuery
{
    public class GetDataTypeByIdQuery
        : IRequest<GetDataTypeByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
