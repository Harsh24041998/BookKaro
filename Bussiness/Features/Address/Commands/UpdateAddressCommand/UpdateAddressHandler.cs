using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.Address.Commands.UpdateAddressCommand
{
    public class UpdateAddressHandler : IRequestHandler<UpdateAddressCommand, UpdateAddressCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAddressRepository _AddressRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateAddressHandler(IUnitOfWork unitOfWork, IMapper mapper, IAddressRepository AddressRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _AddressRepository = AddressRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateAddressCommandDTO> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var AddressResponse = new UpdateAddressCommandDTO();
                var requestModel = request.Id;
                var convertToAddressDO = _mapper.Map<AddressDO>(request);

                string propertiesToInclude = "";
                var response = await _AddressRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
                if (response != null)
                {

                    var userClaims = _httpContextAccessor.HttpContext.User.Claims;
                    var OrganizationId = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.NameId)?.Value;
                    var Town = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Address)?.Value;
                    var City = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Name)?.Value;
                    var State = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Name)?.Value;
                    var Pincode = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Name)?.Value;
                    var Country = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Name)?.Value;
                    var empCode = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.Sid)?.Value;
                    var userId = userClaims.FirstOrDefault(c => c.Value == JwtRegisteredClaimNames.NameId || c.Value == ClaimTypes.NameIdentifier)?.Value;


                    response.Address = request.Address == response.Address ? response.Address : request.Address;
                    response.Town = request.Town == response.Town ? response.Town : request.Town;
                    response.City = request.City == response.City ? response.City : request.City;
                    response.State = request.State == response.State ? response.State : request.State;
                    response.Pincode = request.Pincode == response.Pincode ? response.Pincode : request.Pincode;
                    response.Country = request.Country == response.Country ? response.Country : request.Country;
                    response.OrganizationId = request.OrganizationId == response.OrganizationId ? response.OrganizationId : request.OrganizationId;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _AddressRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToAddressDtO = _mapper.Map<UpdateAddressCommandDTO>(result);
                    return convertToAddressDtO;
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
