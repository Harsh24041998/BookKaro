using FluentValidation;

namespace Bussiness.Features.Address.Commands.DeleteAddressCommand
{
    public class DeleteAddressValidator : AbstractValidator<DeleteAddressCommand>
    {
        #region Ctor

        public DeleteAddressValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
