using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAssetCancellationPolicy.Commands.UpdateCoreAssetCancellationPolicyCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.CoreAssetCancellationPolicy.Commands.UpdateCoreAssetCancellationPolicyCommand
{
    public class UpdateCoreAssetCancellationPolicyHandler : IRequestHandler<UpdateCoreAssetCancellationPolicyCommand, UpdateCoreAssetCancellationPolicyCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetCancellationPolicyRepository _CoreAssetCancellationPolicyRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateCoreAssetCancellationPolicyHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetCancellationPolicyRepository CoreAssetCancellationPolicyRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetCancellationPolicyRepository = CoreAssetCancellationPolicyRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateCoreAssetCancellationPolicyCommandDTO> Handle(UpdateCoreAssetCancellationPolicyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetCancellationPolicyResponse = new UpdateCoreAssetCancellationPolicyCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetCancellationPolicyDO = _mapper.Map<CoreAssetCancellationPolicyDO>(request);

                string propertiesToInclude = "";
                var response = await _CoreAssetCancellationPolicyRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
                if (response != null)
                {

                    var userClaims = _httpContextAccessor.HttpContext.User.Claims;
                    var firstName = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value;
                    var LastName = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Nickname)?.Value;
                    var empCode = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;
                    var email = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email || c.Type == ClaimTypes.Email)?.Value;
                    var phoneNumber = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.PhoneNumber)?.Value;
                    var userId = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId || c.Type == ClaimTypes.NameIdentifier)?.Value;



                    response.AssetId = request.AssetId == response.AssetId ? response.AssetId : request.AssetId;
                    response.PriorUptillPeriod = request.PriorUptillPeriod == response.PriorUptillPeriod ? response.PriorUptillPeriod : request.PriorUptillPeriod;
                    response.ReturnRate = request.ReturnRate == response.ReturnRate ? response.ReturnRate : request.ReturnRate;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _CoreAssetCancellationPolicyRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToCoreAssetCancellationPolicyDtO = _mapper.Map<UpdateCoreAssetCancellationPolicyCommandDTO>(result);
                    return convertToCoreAssetCancellationPolicyDtO;
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
