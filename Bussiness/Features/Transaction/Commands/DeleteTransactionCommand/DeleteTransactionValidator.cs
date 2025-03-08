using FluentValidation;

namespace Bussiness.Features.Transaction.Commands.DeleteTransactionCommand
{
    public class DeleteTransactionValidator : AbstractValidator<DeleteTransactionCommand>
    {
        #region Ctor

        public DeleteTransactionValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
