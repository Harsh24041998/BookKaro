using MediatR;

namespace Bussiness.Features.Subscription.Commands.CreateSubscriptionCommand
{
    public class CreateSubscriptionCommand : IRequest<CreateSubscriptionCommandDTO>
    {
        #region Properties

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; } = 0;
        public int DiscountRate { get; set; } = 0;
        public bool IsActive { get; set; } = false;

        #endregion
    }
}
