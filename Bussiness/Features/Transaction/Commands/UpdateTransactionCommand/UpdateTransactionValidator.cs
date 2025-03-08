using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.Transaction.Commands.UpdateTransactionCommand
{
    public class UpdateTransactionValidator
        : AbstractValidator<UpdateTransactionCommand>
    {
        #region Fields

        private readonly ITransactionRepository _TransactionRepository;

        #endregion

        #region Ctor

        public UpdateTransactionValidator(ITransactionRepository TransactionRepository)
        {
            _TransactionRepository = TransactionRepository;

            //Rule Writing
            RuleFor(x => x.Particular)
                .NotEmpty().WithMessage("Particular cannot be empty.")
                .NotNull().WithMessage("Particular is required.")
                .MinimumLength(2).WithMessage("Particular must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Particular cannot exceed 50 characters.");

            RuleFor(x => x.OrganizationId)
                .NotEmpty().WithMessage("Organizationd cannot be empty.")
                .NotNull().WithMessage("OrganizationId is required.");

            RuleFor(x => x.TransactionStatusEnumValueId)
                .NotEmpty().WithMessage("TransactionStatusEnumValueId cannot be empty.")
                .NotNull().WithMessage("TransactionStatusEnumValueId is required.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Amount cannot be empty.")
                .NotNull().WithMessage("Amount is required.");
        }

        #endregion

        #region Methods



        #endregion
    }
}
