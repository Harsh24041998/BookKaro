using MediatR;

namespace Bussiness.Features.Industry.Commands.CreateIndustryCommand
{
    public class CreateIndustryCommand : IRequest<CreateIndustryCommandDTO>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = default;

        #endregion
    }
}
