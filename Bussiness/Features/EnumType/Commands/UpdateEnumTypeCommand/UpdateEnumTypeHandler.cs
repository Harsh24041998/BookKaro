using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.EnumType.Commands.UpdateEnumTypeCommand
{
    public class UpdateEnumTypeHandler : IRequestHandler<UpdateEnumTypeCommand, UpdateEnumTypeCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEnumTypeRepository _EnumTypeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateEnumTypeHandler(IUnitOfWork unitOfWork, IMapper mapper, IEnumTypeRepository EnumTypeRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _EnumTypeRepository = EnumTypeRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateEnumTypeCommandDTO> Handle(UpdateEnumTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var EnumTypeResponse = new UpdateEnumTypeCommandDTO();
                var requestModel = request.Id;
                var convertToEnumTypeDO = _mapper.Map<EnumTypeDO>(request);

                string propertiesToInclude = "";
                var response = await _EnumTypeRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
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
                    response.Description = request.Description == response.Description ? response.Description : request.Description;
                    response.IsActive = request.IsActive == response.IsActive ? response.IsActive : request.IsActive;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _EnumTypeRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToEnumTypeDtO = _mapper.Map<UpdateEnumTypeCommandDTO>(result);
                    return convertToEnumTypeDtO;
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
