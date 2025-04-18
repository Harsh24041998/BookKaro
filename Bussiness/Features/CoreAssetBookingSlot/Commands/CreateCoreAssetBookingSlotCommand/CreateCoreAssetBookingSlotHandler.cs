﻿using AutoMapper;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using Bussiness.Enums;
using Bussiness.Features.CoreAssetBooking.Commands.CreateCoreAssetBookingCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Features.CoreAssetBookingSlot.Commands.CreateCoreAssetBookingSlotCommand
{
    public class CreateCoreAssetBookingSlotHandler
        : IRequestHandler<CreateCoreAssetBookingSlotCommand, CreateCoreAssetBookingSlotCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public CreateCoreAssetBookingSlotHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods

        public async Task<CreateCoreAssetBookingSlotCommandDTO> Handle(CreateCoreAssetBookingSlotCommand request, CancellationToken cancellationToken)
        {
            try
            {
                CoreAssetBookingSlotDO CoreAssetBookingSlot = _mapper.Map<CoreAssetBookingSlotDO>(request);

                await _unitOfWork.BeginTransactionAsync(cancellationToken);


                var userClaims = _httpContextAccessor.HttpContext.User.Claims;
                var firstName = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Name)?.Value;
                var LastName = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Nickname)?.Value;
                var empCode = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Sid)?.Value;
                var email = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Email || c.Value == ClaimTypes.Email)?.Value;
                var phoneNumber = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.PhoneNumber)?.Value;
                var userId = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.NameId || c.Value == ClaimTypes.NameIdentifier)?.Value;


                CoreAssetBookingSlot.CreatedBy = empCode.ToString();
                CoreAssetBookingSlot.CreatedOn = DateTime.Now;

                var result = await _unitOfWork.CoreAssetBookingSlotRepository.Create(CoreAssetBookingSlot, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return _mapper.Map<CreateCoreAssetBookingSlotCommandDTO>(result);
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
