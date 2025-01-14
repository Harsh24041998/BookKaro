using FluentValidation;

namespace Bussiness.Features.Authentication.VerifyOTP
{
    public class VerifyOTPCommandValidator : AbstractValidator<VerifyOTPCommand>
    {
        #region Fields


        #endregion

        #region Ctor

        public VerifyOTPCommandValidator()
        {
            RuleFor(x => x.MobileNumber)
                .NotEmpty().WithMessage("Mobile Number cannot be empty.")
                .NotNull().WithMessage("Mobile Number is required.")
                .MinimumLength(10).WithMessage("Mobile Number must be 10 Digits.")
                .MaximumLength(10).WithMessage("Mobile Number must be 10 Digits.");

            RuleFor(x => x.OTP)
                .NotEmpty().WithMessage("Mobile Number cannot be empty.")
                .NotNull().WithMessage("Mobile Number is required.");
        }

        #endregion

        #region Methods

        #endregion    
    }
}
