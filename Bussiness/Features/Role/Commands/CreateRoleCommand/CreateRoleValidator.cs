﻿using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.Role.Commands.CreateRoleCommand
{
    public class CreateRoleValidator
        : AbstractValidator<CreateRoleCommand>
    {
        #region Fields

        private readonly IRoleRepository _RoleRepository;

        #endregion

        #region Ctor

        public CreateRoleValidator(IRoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;

            //Rule Writing
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.")
                .Must(ValidateIfRoleDoesNotExist).WithMessage("Role already exists");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .NotNull().WithMessage("Description is required.")
                .MinimumLength(2).WithMessage("Description must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Description cannot exceed 100 characters.");
        }

        #endregion

        #region Methods

        private bool ValidateIfRoleDoesNotExist(string? activityName)
        {
            var results = _RoleRepository.ReadAllAsNoTracking().Where(e => e.Name == activityName).FirstOrDefault();

            return results == null ? true : false;
        }

        #endregion
    }
}
