using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAssetSubscription.Commands.UpdateCoreAssetSubscriptionCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.CoreAssetSubscription.Commands.UpdateCoreAssetSubscriptionCommand
{
    public class UpdateCoreAssetSubscriptionHandler : IRequestHandler<UpdateCoreAssetSubscriptionCommand, UpdateCoreAssetSubscriptionCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetSubscriptionRepository _CoreAssetSubscriptionRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateCoreAssetSubscriptionHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetSubscriptionRepository CoreAssetSubscriptionRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetSubscriptionRepository = CoreAssetSubscriptionRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateCoreAssetSubscriptionCommandDTO> Handle(UpdateCoreAssetSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetSubscriptionResponse = new UpdateCoreAssetSubscriptionCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetSubscriptionDO = _mapper.Map<CoreAssetSubscriptionDO>(request);

                string propertiesToInclude = "";
                var response = await _CoreAssetSubscriptionRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
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
                    response.AmountPaid = request.AmountPaid == response.AmountPaid ? response.AmountPaid : request.AmountPaid;
                    response.DaysLeftForExpiry = request.DaysLeftForExpiry == response.DaysLeftForExpiry ? response.DaysLeftForExpiry : request.DaysLeftForExpiry;
                    response.IsExpired = request.IsExpired == response.IsExpired ? response.IsExpired : request.IsExpired;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _CoreAssetSubscriptionRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToCoreAssetSubscriptionDtO = _mapper.Map<UpdateCoreAssetSubscriptionCommandDTO>(result);
                    return convertToCoreAssetSubscriptionDtO;
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
