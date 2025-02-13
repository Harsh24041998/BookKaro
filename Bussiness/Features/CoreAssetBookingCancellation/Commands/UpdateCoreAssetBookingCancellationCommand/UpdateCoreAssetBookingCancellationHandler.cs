using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAssetBookingCancellation.Commands.UpdateCoreAssetBookingCancellationCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.CoreAssetBookingCancellation.Commands.UpdateCoreAssetBookingCancellationCommand
{
    public class UpdateCoreAssetBookingCancellationHandler : IRequestHandler<UpdateCoreAssetBookingCancellationCommand, UpdateCoreAssetBookingCancellationCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetBookingCancellationRepository _CoreAssetBookingCancellationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateCoreAssetBookingCancellationHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetBookingCancellationRepository CoreAssetBookingCancellationRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetBookingCancellationRepository = CoreAssetBookingCancellationRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateCoreAssetBookingCancellationCommandDTO> Handle(UpdateCoreAssetBookingCancellationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetBookingCancellationResponse = new UpdateCoreAssetBookingCancellationCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetBookingCancellationDO = _mapper.Map<CoreAssetBookingCancellationDO>(request);

                string propertiesToInclude = "";
                var response = await _CoreAssetBookingCancellationRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
                if (response != null)
                {

                    var userClaims = _httpContextAccessor.HttpContext.User.Claims;
                    var firstName = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value;
                    var LastName = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Nickname)?.Value;
                    var empCode = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;
                    var email = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email || c.Type == ClaimTypes.Email)?.Value;
                    var phoneNumber = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.PhoneNumber)?.Value;
                    var userId = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId || c.Type == ClaimTypes.NameIdentifier)?.Value;



                    response.AssetBookingId = request.AssetBookingId == response.AssetBookingId ? response.AssetBookingId : request.AssetBookingId;
                    response.Amount = request.Amount == response.Amount ? response.Amount : request.Amount;
                    response.Refund = request.Refund == response.Refund ? response.Refund : request.Refund;
                    response.BankAccountName = request.BankAccountName == response.BankAccountName ? response.BankAccountName : request.BankAccountName;
                    response.BankAccountNo = request.BankAccountNo == response.BankAccountNo ? response.BankAccountNo : request.BankAccountNo;
                    response.BankIfscCode = request.BankIfscCode == response.BankIfscCode ? response.BankIfscCode : request.BankIfscCode;
                    response.Status = request.Status == response.Status ? response.Status : request.Status;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _CoreAssetBookingCancellationRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToCoreAssetBookingCancellationDtO = _mapper.Map<UpdateCoreAssetBookingCancellationCommandDTO>(result);
                    return convertToCoreAssetBookingCancellationDtO;
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
