using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.Role.Commands.DeleteRoleCommand
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, DeleteRoleCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _RoleRepository;

        #endregion

        #region Ctor

        public DeleteRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IRoleRepository RoleRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _RoleRepository = RoleRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteRoleCommandDTO> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteRoleCommandDTO();
                var requestModel = request.Id;
                var convertToRoleDO = _mapper.Map<RoleDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _RoleRepository.Delete(convertToRoleDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToRoleDtO = _mapper.Map<DeleteRoleCommandDTO>(result);
                return convertToRoleDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
