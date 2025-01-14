using AutoMapper;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using Bussiness.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bussiness.Features.Industry.Commands.CreateIndustryCommand
{
    public class CreateIndustryHandler
        : IRequestHandler<CreateIndustryCommand, CreateIndustryCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public CreateIndustryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods

        public async Task<CreateIndustryCommandDTO> Handle(CreateIndustryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                IndustryDO Industry = _mapper.Map<IndustryDO>(request);

                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                string IndustryCodeString = SequenceCodes.Industry.ToString();
                Industry.Code = "";//await _unitOfWork.SequenceRepository.GenerateNext(IndustryCodeString, cancellationToken);

                var userClaims = _httpContextAccessor.HttpContext.User.Claims;
                var firstName = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value;
                var LastName = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Nickname)?.Value;
                var empCode = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;
                var email = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email || c.Type == ClaimTypes.Email)?.Value;
                var phoneNumber = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.PhoneNumber)?.Value;
                var userId = userClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId || c.Type == ClaimTypes.NameIdentifier)?.Value;


                Industry.CreatedBy = empCode.ToString();
                Industry.CreatedOn = DateTime.Now;

                var result = await _unitOfWork.IndustryRepository.Create(Industry, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return _mapper.Map<CreateIndustryCommandDTO>(result);
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
