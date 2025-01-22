using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.CoreAsset.Commands.UpdateCoreAssetCommand
{
    public class UpdateCoreAssetValidator
        : AbstractValidator<UpdateCoreAssetCommand>
    {
        #region Fields

        private readonly ICoreAssetRepository _CoreAssetRepository;

        #endregion

        #region Ctor

        public UpdateCoreAssetValidator(ICoreAssetRepository CoreAssetRepository)
        {
            _CoreAssetRepository = CoreAssetRepository;

            //Rule Writing
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.")
                .Must(ValidateIfModuleDoesNotExist).WithMessage("Group already exists");

            RuleFor(x => x.AssetNo)
                .NotEmpty().WithMessage("AssetNo cannot be empty.")
                .NotNull().WithMessage("AssetNo is required.");

            RuleFor(x => x.Priority)
                .NotEmpty().WithMessage("Priority cannot be empty.")
                .NotNull().WithMessage("Priority is required.");

            RuleFor(x => x.SlotInterval)
                .NotEmpty().WithMessage("SlotInterval cannot be empty.")
                .NotNull().WithMessage("SlotInterval is required.");
        }

        #endregion

        #region Methods

        private bool ValidateIfModuleDoesNotExist(string? activityName)
        {
            var results = _CoreAssetRepository.ReadAllAsNoTracking().Where(e => e.Name == activityName).FirstOrDefault();

            return results == null ? true : false;
        }

        #endregion
    }
}
