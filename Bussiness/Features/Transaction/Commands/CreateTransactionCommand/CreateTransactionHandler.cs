using AutoMapper;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using Bussiness.Features.Transaction.Commands.CreateTransactionCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Features.Transaction.Commands.CreateTransactionCommand
{
    public class CreateTransactionHandler
        : IRequestHandler<CreateTransactionCommand, CreateTransactionCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public CreateTransactionHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods

        public async Task<CreateTransactionCommandDTO> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                TransactionDO Transaction = _mapper.Map<TransactionDO>(request);

                await _unitOfWork.BeginTransactionAsync(cancellationToken);


                var userClaims = _httpContextAccessor.HttpContext.User.Claims;
                var OrganizationId = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.NameId)?.Value;
                var Town = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Address)?.Value;
                var City = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Name)?.Value;
                var State = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Name)?.Value;
                var Pincode = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Name)?.Value;
                var Country = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Name)?.Value;
                var empCode = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Sid)?.Value;
                var userId = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.NameId || c.Value == ClaimTypes.NameIdentifier)?.Value;



                Transaction.CreatedBy = empCode.ToString();
                Transaction.CreatedOn = DateTime.Now;

                var result = await _unitOfWork.TransactionRepository.Create(Transaction, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return _mapper.Map<CreateTransactionCommandDTO>(result);
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
