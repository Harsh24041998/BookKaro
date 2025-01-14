using MediatR;

namespace Bussiness.Features.User.Queries.GetUserByMobileNumberQuery
{
    public class GetUserByMobileNumberQuery
        : IRequest<GetUserByMobileNumberDTO>
    {
        #region properties

        public string? MobileNumber { get; set; }

        #endregion
    }
}
