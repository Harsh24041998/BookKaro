using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.CoreAssetTemplate.Commands.UpdateCoreAssetTemplateCommand
{
    public class UpdateCoreAssetTemplateHandler : IRequestHandler<UpdateCoreAssetTemplateCommand, UpdateCoreAssetTemplateCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetTemplateRepository _CoreAssetTemplateRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateCoreAssetTemplateHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetTemplateRepository CoreAssetTemplateRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetTemplateRepository = CoreAssetTemplateRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateCoreAssetTemplateCommandDTO> Handle(UpdateCoreAssetTemplateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetTemplateResponse = new UpdateCoreAssetTemplateCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetTemplateDO = _mapper.Map<CoreAssetTemplateDO>(request);

                string propertiesToInclude = "";
                var response = await _CoreAssetTemplateRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
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
                    response.DayEnumValueId = request.DayEnumValueId == response.DayEnumValueId ? response.DayEnumValueId : request.DayEnumValueId;
                    response.StartTime = request.StartTime == response.StartTime ? response.StartTime : request.StartTime;
                    response.EndTime = request.EndTime == response.EndTime ? response.EndTime : request.EndTime;
                    response.Rate = request.Rate == response.Rate ? response.Rate : request.Rate;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _CoreAssetTemplateRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToCoreAssetTemplateDtO = _mapper.Map<UpdateCoreAssetTemplateCommandDTO>(result);
                    return convertToCoreAssetTemplateDtO;
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
