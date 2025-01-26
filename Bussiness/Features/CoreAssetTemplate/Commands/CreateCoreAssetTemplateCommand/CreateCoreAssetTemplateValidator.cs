using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.CoreAssetTemplate.Commands.CreateCoreAssetTemplateCommand
{
    public class CreateCoreAssetTemplateValidator
        : AbstractValidator<CreateCoreAssetTemplateCommand>
    {
        #region Fields

        private readonly ICoreAssetTemplateRepository _CoreAssetTemplateRepository;

        #endregion

        #region Ctor

        public CreateCoreAssetTemplateValidator(ICoreAssetTemplateRepository CoreAssetTemplateRepository)
        {
            _CoreAssetTemplateRepository = CoreAssetTemplateRepository;

            //Rule Writing
            RuleFor(x => x.AssetId)
                .NotEmpty().WithMessage("AssetId cannot be empty.")
                .NotNull().WithMessage("AssetId is required.");

            RuleFor(x => x.DayEnumValueId)
                .NotEmpty().WithMessage("DayEnumValueId cannot be empty.")
                .NotNull().WithMessage("DayEnumValueId is required.");

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

        #region Methods

        

        #endregion
    }
}
