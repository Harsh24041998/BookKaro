using FluentValidation;

namespace Bussiness.Features.CoreAssetBookingSlot.Queries.GetCoreAssetBookingSlotByIdQuery
{
    public class GetCoreAssetBookingSlotByIdQueryValidator
        : AbstractValidator<GetCoreAssetBookingSlotByIdQuery>
    {
        #region Ctor

        public GetCoreAssetBookingSlotByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
