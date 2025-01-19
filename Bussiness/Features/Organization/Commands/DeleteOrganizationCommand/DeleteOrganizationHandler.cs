using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;

namespace Bussiness.Features.Organization.Commands.DeleteOrganizationCommand
{
    public class DeleteOrganizationHandler : IRequestHandler<DeleteOrganizationCommand, DeleteOrganizationCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrganizationRepository _OrganizationRepository;

        #endregion

        #region Ctor

        public DeleteOrganizationHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrganizationRepository OrganizationRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _OrganizationRepository = OrganizationRepository;
        }

        #endregion

        #region methods

        public async Task<DeleteOrganizationCommandDTO> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentResponse = new DeleteOrganizationCommandDTO();
                var requestModel = request.Id;
                var convertToOrganizationDO = _mapper.Map<OrganizationDO>(request);

                //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var result = await _OrganizationRepository.Delete(convertToOrganizationDO, cancellationToken);
                //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                var convertToOrganizationDtO = _mapper.Map<DeleteOrganizationCommandDTO>(result);
                return convertToOrganizationDtO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
