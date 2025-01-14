using MediatR;

namespace Bussiness.Features.Gender.Commands.CreateGenderCommand
{
    public class CreateGenderCommand : IRequest<CreateGenderCommandDTO>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = default;

        #endregion
    }
}
