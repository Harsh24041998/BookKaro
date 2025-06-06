﻿using MediatR;

namespace Bussiness.Features.Industry.Commands.UpdateIndustryCommand
{
    public class UpdateIndustryCommand : IRequest<UpdateIndustryCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = default;

        #endregion
    }
}
