using FluentValidation;

namespace Bussiness.Features.Industry.Commands.DeleteIndustryCommand
{
    public class DeleteIndustryValidator : AbstractValidator<DeleteIndustryCommand>
    {
        #region Ctor

        public DeleteIndustryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
