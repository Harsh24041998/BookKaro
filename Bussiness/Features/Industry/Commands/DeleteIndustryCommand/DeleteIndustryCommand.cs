using MediatR;

namespace Bussiness.Features.Industry.Commands.DeleteIndustryCommand
{
    public class DeleteIndustryCommand : IRequest<DeleteIndustryCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
