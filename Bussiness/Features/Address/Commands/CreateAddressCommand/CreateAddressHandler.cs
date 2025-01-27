using AutoMapper;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bussiness.Features.Address.Commands.CreateAddressCommand
{
    public class CreateAddressHandler
        : IRequestHandler<CreateAddressCommand, CreateAddressCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public CreateAddressHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods

        public async Task<CreateAddressCommandDTO> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                AddressDO Address = _mapper.Map<AddressDO>(request);

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



                Address.CreatedBy = empCode.ToString();
                Address.CreatedOn = DateTime.Now;

                var result = await _unitOfWork.AddressRepository.Create(Address, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return _mapper.Map<CreateAddressCommandDTO>(result);
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
