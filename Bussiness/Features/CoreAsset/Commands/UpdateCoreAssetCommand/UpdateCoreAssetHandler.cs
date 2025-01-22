using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAsset.Commands.UpdateCoreAssetCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.CoreAsset.Commands.UpdateCoreAssetCommand
{
    public class UpdateCoreAssetHandler : IRequestHandler<UpdateCoreAssetCommand, UpdateCoreAssetCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetRepository _CoreAssetRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateCoreAssetHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetRepository CoreAssetRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetRepository = CoreAssetRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateCoreAssetCommandDTO> Handle(UpdateCoreAssetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetResponse = new UpdateCoreAssetCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetDO = _mapper.Map<CoreAssetDO>(request);

                string propertiesToInclude = "";
                var response = await _CoreAssetRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
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
                    response.OrganizationID = request.OrganizationID == response.OrganizationID ? response.OrganizationID : request.OrganizationID;
                    response.CategoryID = request.CategoryID == response.CategoryID ? response.CategoryID : request.CategoryID;
                    response.IsOnline = request.IsOnline == response.IsOnline ? response.IsOnline : request.IsOnline;
                    response.AssetNo = request.AssetNo == response.AssetNo ? response.AssetNo : request.AssetNo;
                    response.Priority = request.Priority == response.Priority ? response.Priority : request.Priority;
                    response.SlotInterval = request.SlotInterval == response.SlotInterval ? response.SlotInterval : request.SlotInterval;
                    
                    response.IsActive = request.IsActive == response.IsActive ? response.IsActive : request.IsActive;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _CoreAssetRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToCoreAssetDtO = _mapper.Map<UpdateCoreAssetCommandDTO>(result);
                    return convertToCoreAssetDtO;
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
