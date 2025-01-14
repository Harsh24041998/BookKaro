using MediatR;

namespace Bussiness.Features.EnumType.Queries.GetAllEnumTypeByNameQuery
{
    public class GetAllEnumTypeByNameQuery
         : IRequest<GetAllEnumTypeByNameDTO>
    {
        #region properties

        public string? Name { get; set; }

        #endregion
    }
}
