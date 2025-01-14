using FluentValidation;

namespace Bussiness.Features.Authentication.SendOTP
{
    public class SendOTPCommandValidator : AbstractValidator<SendOTPCommand>
    {
        #region Fields


        #endregion

        #region Ctor

        public SendOTPCommandValidator()
        {
            RuleFor(x => x.MobileNumber)
                .NotEmpty().WithMessage("Mobile Number cannot be empty.")
                .NotNull().WithMessage("Mobile Number is required.")
                .MinimumLength(10).WithMessage("Mobile Number must be 10 Digits.")
                .MaximumLength(10).WithMessage("Mobile Number must be 10 Digits.");
        }

        #endregion

        #region Methods

        #endregion    
    }
}
