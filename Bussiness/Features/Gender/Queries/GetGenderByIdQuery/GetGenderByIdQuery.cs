using MediatR;

namespace Bussiness.Features.Gender.Queries.GetGenderByIdQuery
{
    public class GetGenderByIdQuery
        : IRequest<GetGenderByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
