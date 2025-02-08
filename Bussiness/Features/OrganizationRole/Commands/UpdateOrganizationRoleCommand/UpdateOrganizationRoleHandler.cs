using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.OrganizationRole.Commands.UpdateOrganizationRoleCommand
{
    public class UpdateOrganizationRoleHandler : IRequestHandler<UpdateOrganizationRoleCommand, UpdateOrganizationRoleCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrganizationRoleRepository _OrganizationRoleRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateOrganizationRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrganizationRoleRepository OrganizationRoleRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _OrganizationRoleRepository = OrganizationRoleRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateOrganizationRoleCommandDTO> Handle(UpdateOrganizationRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var OrganizationRoleResponse = new UpdateOrganizationRoleCommandDTO();
                var requestModel = request.Id;
                var convertToOrganizationRoleDO = _mapper.Map<OrganizationRoleDO>(request);

                string propertiesToInclude = "";
                var response = await _OrganizationRoleRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
                if (response != null)
                {

                    var userClaims = _httpContextAccessor.HttpContext.User.Claims;

                    var empCode = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;

                    var userId = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId || c.Type == ClaimTypes.NameIdentifier)?.Value;
                    var RoleId = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId || c.Type == ClaimTypes.NameIdentifier)?.Value;
                    var OrganizationId = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId || c.Type == ClaimTypes.NameIdentifier)?.Value;



                    response.UserId = request.UserId == response.UserId ? response.UserId : request.UserId;
                    response.RoleId = request.UserId == response.UserId ? response.UserId : request.UserId;
                    response.OrganizationId = request.OrganizationId == response.OrganizationId ? response.OrganizationId : request.OrganizationId;


                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _OrganizationRoleRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToOrganizationRoleDtO = _mapper.Map<UpdateOrganizationRoleCommandDTO>(result);
                    return convertToOrganizationRoleDtO;
                }
                else
                {
                    throw new Exception(message: "No Role found against provided Id");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
