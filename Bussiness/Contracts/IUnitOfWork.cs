using Bussiness.Contracts.Repositories;

namespace Bussiness.Contracts
{
    public interface IUnitOfWork
    {
        #region Properties
        IRoleRepository RoleRepository { get; }
        IGenderRepository GenderRepository { get; }
        IDataTypeRepository DataTypeRepository { get; }
        IEnumTypeRepository EnumTypeRepository { get; }
        IEnumValueRepository EnumValueRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IUserRepository UserRepository { get; }
        IIndustryRepository IndustryRepository { get; }
        IOrganizationRepository OrganizationRepository { get; }
        ICoreAssetRepository CoreAssetRepository { get; }

        #endregion

        #region Methods

        public Task BeginTransactionAsync(CancellationToken cancellationToken);
        public Task CommitTransactionAsync(CancellationToken cancellationToken);
        public Task RollbackTransactionAsync(CancellationToken cancellationToken);
        public Task SaveChangesAsync(CancellationToken cancellationToken);

        #endregion
    }
}
