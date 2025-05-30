﻿using AutoMapper;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bussiness.Features.OrganizationRole.Commands.CreateOrganizationRoleCommand
{
    public class CreateOrganizationRoleHandler
        : IRequestHandler<CreateOrganizationRoleCommand, CreateOrganizationRoleCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public CreateOrganizationRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods

        public async Task<CreateOrganizationRoleCommandDTO> Handle(CreateOrganizationRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                OrganizationRoleDO OrganizationRole = _mapper.Map<OrganizationRoleDO>(request);

                await _unitOfWork.BeginTransactionAsync(cancellationToken);


                var userClaims = _httpContextAccessor.HttpContext.User.Claims;
                var firstName = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Name)?.Value;
 

                OrganizationRole.CreatedBy = ToString();
                OrganizationRole.CreatedOn = DateTime.Now;

                var result = await _unitOfWork.OrganizationRoleRepository.Create(OrganizationRole, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return _mapper.Map<CreateOrganizationRoleCommandDTO>(result);
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
