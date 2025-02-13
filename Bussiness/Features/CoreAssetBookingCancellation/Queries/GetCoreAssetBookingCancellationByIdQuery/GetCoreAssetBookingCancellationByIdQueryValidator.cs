using FluentValidation;

namespace Bussiness.Features.CoreAssetBookingCancellation.Queries.GetCoreAssetBookingCancellationByIdQuery
{
    public class GetCoreAssetBookingCancellationByIdQueryValidator
        : AbstractValidator<GetCoreAssetBookingCancellationByIdQuery>
    {
        #region Ctor

        public GetCoreAssetBookingCancellationByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
