﻿using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.EnumValue.Commands.UpdateEnumValueCommand
{
    public class UpdateEnumValueHandler : IRequestHandler<UpdateEnumValueCommand, UpdateEnumValueCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEnumValueRepository _EnumValueRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateEnumValueHandler(IUnitOfWork unitOfWork, IMapper mapper, IEnumValueRepository EnumValueRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _EnumValueRepository = EnumValueRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateEnumValueCommandDTO> Handle(UpdateEnumValueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var EnumValueResponse = new UpdateEnumValueCommandDTO();
                var requestModel = request.Id;
                var convertToEnumValueDO = _mapper.Map<EnumValueDO>(request);

                string propertiesToInclude = "";
                var response = await _EnumValueRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
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
                    response.EnumTypeId = request.EnumTypeId == response.EnumTypeId ? response.EnumTypeId : request.EnumTypeId;
                    response.IsActive = request.IsActive == response.IsActive ? response.IsActive : request.IsActive;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _EnumValueRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToEnumValueDtO = _mapper.Map<UpdateEnumValueCommandDTO>(result);
                    return convertToEnumValueDtO;
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
