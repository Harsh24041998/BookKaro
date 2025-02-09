using FluentValidation;

namespace Bussiness.Features.CoreAssetBooking.Queries.GetCoreAssetBookingByIdQuery
{
    public class GetCoreAssetBookingByIdQueryValidator
        : AbstractValidator<GetCoreAssetBookingByIdQuery>
    {
        #region Ctor

        public GetCoreAssetBookingByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
