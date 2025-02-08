using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.OrganizationRole.Commands.DeleteOrganizationRoleCommand
{
    public class DeleteOrganizationRoleHandler : IRequestHandler<DeleteOrganizationRoleCommand, DeleteOrganizationRoleCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrganizationRoleRepository _OrganizationRoleRepository;

        #endregion

        #region Ctor

        public DeleteOrganizationRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrganizationRoleRepository OrganizationRoleRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _OrganizationRoleRepository = OrganizationRoleRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteOrganizationRoleCommandDTO> Handle(DeleteOrganizationRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteOrganizationRoleCommandDTO();
                var requestModel = request.Id;
                var convertToOrganizationRoleDO = _mapper.Map<OrganizationRoleDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _OrganizationRoleRepository.Delete(convertToOrganizationRoleDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToOrganizationRoleDtO = _mapper.Map<DeleteOrganizationRoleCommandDTO>(result);
                return convertToOrganizationRoleDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
