namespace Bussiness.Features.Subscription.Queries.GetSubscriptionByIdQuery
{
    public class GetSubscriptionByIdDTO
    {
        #region Properties

        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public int? DiscountRate { get; set; }
        public bool? IsActive { get; set; }

        #endregion
    }
}
