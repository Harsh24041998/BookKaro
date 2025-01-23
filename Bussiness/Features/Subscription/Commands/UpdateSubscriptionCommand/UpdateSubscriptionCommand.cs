using MediatR;

namespace Bussiness.Features.Subscription.Commands.UpdateSubscriptionCommand
{
    public class UpdateSubscriptionCommand : IRequest<UpdateSubscriptionCommandDTO>
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int DiscountRate { get; set; }
        public bool IsActive { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; }

        #endregion
    }
}
