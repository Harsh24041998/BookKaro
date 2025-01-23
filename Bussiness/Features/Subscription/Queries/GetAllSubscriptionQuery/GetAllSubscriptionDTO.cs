namespace Bussiness.Features.Subscription.Queries.GetAllSubscriptionQuery
{
    public class GetAllSubscriptionDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int DiscountRate { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}
