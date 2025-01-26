using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.CoreAssetCustomTemplate.Commands.CreateCoreAssetCustomTemplateCommand
{
    public class CreateCoreAssetCustomTemplateValidator
        : AbstractValidator<CreateCoreAssetCustomTemplateCommand>
    {
        #region Fields

        private readonly ICoreAssetCustomTemplateRepository _CoreAssetCustomTemplateRepository;

        #endregion

        #region Ctor

        public CreateCoreAssetCustomTemplateValidator(ICoreAssetCustomTemplateRepository CoreAssetCustomTemplateRepository)
        {
            _CoreAssetCustomTemplateRepository = CoreAssetCustomTemplateRepository;

            //Rule Writing
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

        #region Methods



        #endregion
    }
}
