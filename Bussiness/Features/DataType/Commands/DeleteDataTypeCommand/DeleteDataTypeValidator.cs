using FluentValidation;

namespace Bussiness.Features.DataType.Commands.DeleteDataTypeCommand
{
    public class DeleteDataTypeValidator : AbstractValidator<DeleteDataTypeCommand>
    {
        #region Ctor

        public DeleteDataTypeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
