using Bussiness.Features.CoreAssetCustomTemplate.Commands.UpdateCoreAssetCustomTemplateCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Features.CoreAssetCustomTemplate.Commands.UpdateCoreAssetCustomTemplateCommand
{
    public class UpdateCoreAssetCustomTemplateValidator : AbstractValidator<UpdateCoreAssetCustomTemplateCommand>
    {
        #region Ctor

        public UpdateCoreAssetCustomTemplateValidator()
        {
            RuleFor(x => x.AssetId)
                .NotEmpty().WithMessage("AssetId cannot be empty.")
                .NotNull().WithMessage("AssetId is required.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date cannot be empty.")
                .NotNull().WithMessage("Date is required.");

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("StartTime cannot be empty.")
                .NotNull().WithMessage("StartTime is required.");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("EndTime cannot be empty.")
                .NotNull().WithMessage("EndTime is required.");

            RuleFor(x => x.Rate)
                .NotEmpty().WithMessage("Rate cannot be empty.")
                .NotNull().WithMessage("Rate is required.");
        }

        #endregion
    }
}
