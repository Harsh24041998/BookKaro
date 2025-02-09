using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAssetBooking.Commands.UpdateCoreAssetBookingCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.CoreAssetBookingSlot.Commands.UpdateCoreAssetBookingSlotCommand
{
    public class UpdateCoreAssetBookingSlotHandler : IRequestHandler<UpdateCoreAssetBookingSlotCommand, UpdateCoreAssetBookingSlotCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetBookingSlotRepository _CoreAssetBookingSlotRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateCoreAssetBookingSlotHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetBookingSlotRepository CoreAssetBookingSlotRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetBookingSlotRepository = CoreAssetBookingSlotRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateCoreAssetBookingSlotCommandDTO> Handle(UpdateCoreAssetBookingSlotCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetBookingSlotResponse = new UpdateCoreAssetBookingSlotCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetBookingSlotDO = _mapper.Map<CoreAssetBookingSlotDO>(request);

                string propertiesToInclude = "";
                var response = await _CoreAssetBookingSlotRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
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
                    response.SlotDate = request.SlotDate == response.SlotDate ? response.SlotDate : request.SlotDate;
                    response.StartTime = request.StartTime == response.StartTime ? response.StartTime : request.StartTime;
                    response.EndTime = request.EndTime == response.EndTime ? response.EndTime : request.EndTime;
                    response.Status = request.Status == response.Status ? response.Status : request.Status;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _CoreAssetBookingSlotRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToCoreAssetBookingSlotDtO = _mapper.Map<UpdateCoreAssetBookingSlotCommandDTO>(result);
                    return convertToCoreAssetBookingSlotDtO;
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
