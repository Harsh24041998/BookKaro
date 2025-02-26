using Bussiness.Contracts.Repositories;

namespace Bussiness.Contracts
{
    public interface IUnitOfWork
    {
        #region Properties
        IRoleRepository RoleRepository { get; }
        IGenderRepository GenderRepository { get; }
        IAddressRepository AddressRepository { get; }
        IOrganizationRoleRepository OrganizationRoleRepository { get; }
        IDataTypeRepository DataTypeRepository { get; }
        IEnumTypeRepository EnumTypeRepository { get; }
        IEnumValueRepository EnumValueRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IUserRepository UserRepository { get; }
        IIndustryRepository IndustryRepository { get; }
        IOrganizationRepository OrganizationRepository { get; }
        ICoreAssetRepository CoreAssetRepository { get; }
        ISubscriptionRepository SubscriptionRepository { get; }
        ICoreAssetTemplateRepository CoreAssetTemplateRepository { get; }
        ICoreAssetCustomTemplateRepository CoreAssetCustomTemplateRepository { get; }
        ICoreAssetCancellationPolicyRepository CoreAssetCancellationPolicyRepository { get; }
        ICoreAssetBookingRepository CoreAssetBookingRepository { get; }
        ICoreAssetBookingSlotRepository CoreAssetBookingSlotRepository { get; }
        ICoreAssetBookingCancellationRepository CoreAssetBookingCancellationRepository { get; }
        ICoreAssetSubscriptionRepository CoreAssetSubscriptionRepository { get; }

        #endregion

        #region Methods

        public Task BeginTransactionAsync(CancellationToken cancellationToken);
        public Task CommitTransactionAsync(CancellationToken cancellationToken);
        public Task RollbackTransactionAsync(CancellationToken cancellationToken);
        public Task SaveChangesAsync(CancellationToken cancellationToken);

        #endregion
    }
}
