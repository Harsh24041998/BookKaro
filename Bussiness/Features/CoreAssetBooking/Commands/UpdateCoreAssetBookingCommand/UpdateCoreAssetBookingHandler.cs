using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.CoreAssetBooking.Commands.UpdateCoreAssetBookingCommand
{
    public class UpdateCoreAssetBookingHandler : IRequestHandler<UpdateCoreAssetBookingCommand, UpdateCoreAssetBookingCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetBookingRepository _CoreAssetBookingRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateCoreAssetBookingHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetBookingRepository CoreAssetBookingRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetBookingRepository = CoreAssetBookingRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateCoreAssetBookingCommandDTO> Handle(UpdateCoreAssetBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetBookingResponse = new UpdateCoreAssetBookingCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetBookingDO = _mapper.Map<CoreAssetBookingDO>(request);

                string propertiesToInclude = "";
                var response = await _CoreAssetBookingRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
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
                    response.Name = request.Name == response.Name ? response.Name : request.Name;
                    response.PhoneNo = request.PhoneNo == response.PhoneNo ? response.PhoneNo : request.PhoneNo;
                    response.Amount = request.Amount == response.Amount ? response.Amount : request.Amount;
                    response.Balance = request.Balance == response.Balance ? response.Balance : request.Balance;
                    response.Advance = request.Advance == response.Advance ? response.Advance : request.Advance;
                    response.Status = request.Status == response.Status ? response.Status : request.Status;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _CoreAssetBookingRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToCoreAssetBookingDtO = _mapper.Map<UpdateCoreAssetBookingCommandDTO>(result);
                    return convertToCoreAssetBookingDtO;
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
