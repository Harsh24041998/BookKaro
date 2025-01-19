using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.Organization.Commands.UpdateOrganizationCommand
{
    public class UpdateOrganizationHandler : IRequestHandler<UpdateOrganizationCommand, UpdateOrganizationCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrganizationRepository _OrganizationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateOrganizationHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrganizationRepository OrganizationRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _OrganizationRepository = OrganizationRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateOrganizationCommandDTO> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var OrganizationResponse = new UpdateOrganizationCommandDTO();
                var requestModel = request.Id;
                var convertToOrganizationDO = _mapper.Map<OrganizationDO>(request);

                string propertiesToInclude = "";
                var response = await _OrganizationRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
                if (response != null)
                {

                    var userClaims = _httpContextAccessor.HttpContext.User.Claims;
                    var firstName = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value;
                    var LastName = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Nickname)?.Value;
                    var empCode = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;
                    var email = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email || c.Type == ClaimTypes.Email)?.Value;
                    var phoneNumber = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.PhoneNumber)?.Value;
                    var userId = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId || c.Type == ClaimTypes.NameIdentifier)?.Value;



                    response.Name = request.Name == response.Name ? response.Name : request.Name;
                    response.IsMobile = request.IsMobile == response.IsMobile ? response.IsMobile : request.IsMobile;
                    response.IndustryId = request.IndustryId == response.IndustryId ? response.IndustryId : request.IndustryId;
                    response.IsActive = request.IsActive == response.IsActive ? response.IsActive : request.IsActive;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _OrganizationRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToOrganizationDtO = _mapper.Map<UpdateOrganizationCommandDTO>(result);
                    return convertToOrganizationDtO;
                }
                else
                {
                    throw new Exception(message: "No Enum found against provided Id");
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
