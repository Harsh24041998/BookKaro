using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Bussiness.Features.Transaction.Commands.UpdateTransactionCommand
{
    public class UpdateTransactionHandler : IRequestHandler<UpdateTransactionCommand, UpdateTransactionCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _TransactionRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateTransactionHandler(IUnitOfWork unitOfWork, IMapper mapper, ITransactionRepository TransactionRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _TransactionRepository = TransactionRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateTransactionCommandDTO> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var TransactionResponse = new UpdateTransactionCommandDTO();
                var requestModel = request.Id;
                var convertToTransactionDO = _mapper.Map<TransactionDO>(request);

                string propertiesToInclude = "";
                var response = await _TransactionRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
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


                    
                    response.TransactionStatusEnumValueId = request.TransactionStatusEnumValueId == response.TransactionStatusEnumValueId ? response.TransactionStatusEnumValueId : request.TransactionStatusEnumValueId;
                    response.IsCredited = request.IsCredited == response.IsCredited ? response.IsCredited : request.IsCredited;
                    response.Particular = request.Particular == response.Particular ? response.Particular : request.Particular;
                    response.Amount = request.Amount == response.Amount ? response.Amount : request.Amount;
                    response.OrganizationId = request.OrganizationId == response.OrganizationId ? response.OrganizationId : request.OrganizationId;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _TransactionRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToTransactionDtO = _mapper.Map<UpdateTransactionCommandDTO>(result);
                    return convertToTransactionDtO;
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
