using MediatR;

namespace Bussiness.Features.Subscription.Commands.DeleteSubscriptionCommand
{
    public class DeleteSubscriptionCommand : IRequest<DeleteSubscriptionCommandDTO>
    {
        #region Properties

        public Guid Id { get; set; }

        #endregion
    }
}
