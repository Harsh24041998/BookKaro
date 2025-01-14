using MediatR;

namespace Bussiness.Features.DataType.Queries.GetAllDataTypeByNameQuery
{
    public class GetAllDataTypeByNameQuery
         : IRequest<GetAllDataTypeByNameDTO>
    {
        #region properties

        public string? Name { get; set; }

        #endregion
    }
}
