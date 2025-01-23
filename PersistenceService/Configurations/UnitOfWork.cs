using Bussiness.Contracts;
using Bussiness.Contracts.Repositories;
using PersistenceService.Repositories;

namespace PersistenceService.Configurations
{
    public sealed class UnitOfWork
        : IUnitOfWork, IDisposable
    {
        #region Fields

        private readonly BookKaroDBContext _bookKaroDBContext;
        private IRoleRepository? _roleRepository;
        private IGenderRepository? _genderRepository;
        private IDataTypeRepository? _dataTypeRepository;
        private IEnumTypeRepository? _enumTypeRepository;
        private IEnumValueRepository? _enumValueRepository;
        private ICategoryRepository? _categoryRepository;
        private ICoreAssetRepository? _coreAssetRepository;
        private IOrganizationRepository? _organizationRepository;
        private IIndustryRepository? _industryRepository;
        private IUserRepository? _userRepository;
        private ISubscriptionRepository? _subscriptionRepository;
        #endregion

        #region Properties

        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new RoleRepository(_bookKaroDBContext, true) as IRoleRepository;
                }
                return _roleRepository!;
            }
        }
        public IGenderRepository GenderRepository
        {
            get
            {
                if (_genderRepository == null)
                {
                    _genderRepository = new GenderRepository(_bookKaroDBContext, true) as IGenderRepository;
                }
                return _genderRepository!;
            }
        }
        public IDataTypeRepository DataTypeRepository
        {
            get
            {
                if (_dataTypeRepository == null)
                {
                    _dataTypeRepository = new DataTypeRepository(_bookKaroDBContext, true) as IDataTypeRepository;
                }
                return _dataTypeRepository!;
            }
        }
        public IEnumTypeRepository EnumTypeRepository
        {
            get
            {
                if (_enumTypeRepository == null)
                {
                    _enumTypeRepository = new EnumTypeRepository(_bookKaroDBContext, true) as IEnumTypeRepository;
                }
                return _enumTypeRepository!;
            }
        }
        public IEnumValueRepository EnumValueRepository
        {
            get
            {
                if (_enumValueRepository == null)
                {
                    _enumValueRepository = new EnumValueRepository(_bookKaroDBContext, true) as IEnumValueRepository;
                }
                return _enumValueRepository!;
            }
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_bookKaroDBContext, true) as ICategoryRepository;
                }
                return _categoryRepository!;
            }
        }
        public ICoreAssetRepository CoreAssetRepository
        {
            get
            {
                if (_coreAssetRepository == null)
                {
                    _coreAssetRepository = new CoreAssetRepository(_bookKaroDBContext, true) as ICoreAssetRepository;
                }
                return _coreAssetRepository!;
            }
        }
        public IOrganizationRepository OrganizationRepository
        {
            get
            {
                if (_organizationRepository == null)
                {
                    _organizationRepository = new OrganizationRepository(_bookKaroDBContext, true) as IOrganizationRepository;
                }
                return _organizationRepository!;
            }
        }
        public IIndustryRepository IndustryRepository
        {
            get
            {
                if (_industryRepository == null)
                {
                    _industryRepository = new IndustryRepository(_bookKaroDBContext, true) as IIndustryRepository;
                }
                return _industryRepository!;
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_bookKaroDBContext, true) as IUserRepository;
                }
                return _userRepository!;
            }
        }
        public ISubscriptionRepository SubscriptionRepository
        {
            get
            {
                if (_subscriptionRepository == null)
                {
                    _subscriptionRepository = new SubscriptionRepository(_bookKaroDBContext, true) as ISubscriptionRepository;
                }
                return _subscriptionRepository!;
            }
        }

        #endregion

        #region Ctor

        public UnitOfWork(BookKaroDBContext bookKaroDBContext)
        {
            _bookKaroDBContext = bookKaroDBContext;
        }

        #endregion

        #region methods

        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            if (_bookKaroDBContext.Database.CurrentTransaction == null)
            {
                await _bookKaroDBContext.Database.BeginTransactionAsync(cancellationToken);
            }
        }
        public async Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            if (_bookKaroDBContext.Database.CurrentTransaction != null)
            {
                await _bookKaroDBContext.Database.CurrentTransaction.CommitAsync(cancellationToken);
            }
        }
        public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            if (_bookKaroDBContext.Database.CurrentTransaction != null)
            {
                await _bookKaroDBContext.Database.CurrentTransaction.RollbackAsync(cancellationToken);
            }
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            if (_bookKaroDBContext.Database.CurrentTransaction != null)
            {
                await _bookKaroDBContext.SaveChangesAsync(cancellationToken);
            }
        }
        public void Dispose()
        {
            _bookKaroDBContext.Dispose();
        }

        #endregion
    }
}
