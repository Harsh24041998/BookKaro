﻿using FluentValidation;

namespace Bussiness.Features.DataType.Commands.UpdateDataTypeCommand
{
    public class UpdateDataTypeValidator : AbstractValidator<UpdateDataTypeCommand>
    {
        #region Ctor

        public UpdateDataTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .NotNull().WithMessage("Description is required.")
                .MinimumLength(2).WithMessage("Description must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Description cannot exceed 100 characters.");
        }

        #endregion
    }
}
