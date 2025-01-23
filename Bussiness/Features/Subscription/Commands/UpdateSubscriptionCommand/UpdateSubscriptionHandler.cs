using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.DomainObjects;
using Bussiness.Features.User.Commands.UpdateUserCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Features.Subscription.Commands.UpdateSubscriptionCommand
{
    public class UpdateSubscriptionHandler : IRequestHandler<UpdateSubscriptionCommand, UpdateSubscriptionCommandDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _SubscriptionRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UpdateSubscriptionHandler(IUnitOfWork unitOfWork, IMapper mapper, ISubscriptionRepository SubscriptionRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _SubscriptionRepository = SubscriptionRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods

        public async Task<UpdateSubscriptionCommandDTO> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var SubscriptionResponse = new UpdateSubscriptionCommandDTO();
                var requestModel = request.Id;
                var convertToSubscriptionDO = _mapper.Map<SubscriptionDO>(request);

                string propertiesToInclude = "";
                var response = await _SubscriptionRepository.ReadByIdAsync(request.Id, propertiesToInclude, cancellationToken);
                if (response != null)
                {

                    var SubscriptionClaims = _httpContextAccessor.HttpContext.User.Claims;
                    //var firstName = SubscriptionClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value;
                    //var LastName = SubscriptionClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Nickname)?.Value;
                    //var empCode = SubscriptionClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;
                    //var email = SubscriptionClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email || c.Type == ClaimTypes.Email)?.Value;
                    //var phoneNumber = SubscriptionClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.PhoneNumber)?.Value;
                    //var SubscriptionId = SubscriptionClaims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId || c.Type == ClaimTypes.NameIdentifier)?.Value;



                    response.Name = request.Name == response.Name ? response.Name : request.Name;
                    response.Description = request.Description == response.Description ? response.Description : request.Description;
                    response.Price = request.Price == response.Price ? response.Price : request.Price;
                    response.DiscountRate = request.DiscountRate == response.DiscountRate ? response.DiscountRate : request.DiscountRate;
                    response.IsActive = request.IsActive == response.IsActive ? response.IsActive : request.IsActive;
                    response.UpdatedOn = DateTime.Now;
                    response.UpdatedBy = "Harsh";//empCode.ToString();

                    //await _unitOfWork.BeginTransactionAsync(cancellationToken);
                    var result = await _SubscriptionRepository.Update(response, cancellationToken);

                    //await _unitOfWork.SaveChangesAsync(cancellationToken);
                    //await _unitOfWork.CommitTransactionAsync(cancellationToken);
                    var convertToSubscriptionDtO = _mapper.Map<UpdateSubscriptionCommandDTO>(result);
                    return convertToSubscriptionDtO;
                }
                else
                {
                    throw new Exception(message: "No data found against provided Id");
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
