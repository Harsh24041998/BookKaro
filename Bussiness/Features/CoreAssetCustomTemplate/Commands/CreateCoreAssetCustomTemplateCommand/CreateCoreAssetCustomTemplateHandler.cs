﻿using AutoMapper;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bussiness.Features.CoreAssetCustomTemplate.Commands.CreateCoreAssetCustomTemplateCommand
{
    public class CreateCoreAssetCustomTemplateHandler
        : IRequestHandler<CreateCoreAssetCustomTemplateCommand, CreateCoreAssetCustomTemplateCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public CreateCoreAssetCustomTemplateHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods

        public async Task<CreateCoreAssetCustomTemplateCommandDTO> Handle(CreateCoreAssetCustomTemplateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                CoreAssetCustomTemplateDO CoreAssetCustomTemplate = _mapper.Map<CoreAssetCustomTemplateDO>(request);

                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var userClaims = _httpContextAccessor.HttpContext.User.Claims;
                var firstName = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Name)?.Value;
                var LastName = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Nickname)?.Value;
                var empCode = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Sid)?.Value;
                var email = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Email || c.Value == ClaimTypes.Email)?.Value;
                var phoneNumber = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.PhoneNumber)?.Value;
                var userId = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.NameId || c.Value == ClaimTypes.NameIdentifier)?.Value;


                CoreAssetCustomTemplate.CreatedBy = empCode.ToString();
                CoreAssetCustomTemplate.CreatedOn = DateTime.Now;

                var result = await _unitOfWork.CoreAssetCustomTemplateRepository.Create(CoreAssetCustomTemplate, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return _mapper.Map<CreateCoreAssetCustomTemplateCommandDTO>(result);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);

                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
