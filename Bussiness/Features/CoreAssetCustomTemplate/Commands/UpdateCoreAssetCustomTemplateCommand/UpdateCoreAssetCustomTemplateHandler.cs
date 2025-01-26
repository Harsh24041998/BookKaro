using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using Bussiness.Features.CoreAssetCustomTemplate.Commands.UpdateCoreAssetCustomTemplateCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.CoreAssetCustomTemplate.Commands.UpdateCoreAssetCustomTemplateCommand
{
    public class UpdateCoreAssetCustomTemplateHandler : IRequestHandler<UpdateCoreAssetCustomTemplateCommand, UpdateCoreAssetCustomTemplateCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoreAssetCustomTemplateRepository _CoreAssetCustomTemplateRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateCoreAssetCustomTemplateHandler(IUnitOfWork unitOfWork, IMapper mapper, ICoreAssetCustomTemplateRepository CoreAssetCustomTemplateRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _CoreAssetCustomTemplateRepository = CoreAssetCustomTemplateRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateCoreAssetCustomTemplateCommandDTO> Handle(UpdateCoreAssetCustomTemplateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var CoreAssetCustomTemplateResponse = new UpdateCoreAssetCustomTemplateCommandDTO();
                var requestModel = request.Id;
                var convertToCoreAssetCustomTemplateDO = _mapper.Map<CoreAssetCustomTemplateDO>(request);

                string propertiesToInclude = "";
                var response = await _CoreAssetCustomTemplateRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
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
                    response.Date = request.Date == response.Date ? response.Date : request.Date;
                    response.StartTime = request.StartTime == response.StartTime ? response.StartTime : request.StartTime;
                    response.EndTime = request.EndTime == response.EndTime ? response.EndTime : request.EndTime;
                    response.Rate = request.Rate == response.Rate ? response.Rate : request.Rate;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _CoreAssetCustomTemplateRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToCoreAssetCustomTemplateDtO = _mapper.Map<UpdateCoreAssetCustomTemplateCommandDTO>(result);
                    return convertToCoreAssetCustomTemplateDtO;
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
