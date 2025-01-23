using BookKaroAPI.Response;
using Bussiness.Features.Subscription.Commands.CreateSubscriptionCommand;
using Bussiness.Features.Subscription.Commands.DeleteSubscriptionCommand;
using Bussiness.Features.Subscription.Commands.UpdateSubscriptionCommand;
using Bussiness.Features.Subscription.Queries.GetAllSubscriptionQuery;
using Bussiness.Features.Subscription.Queries.GetSubscriptionByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : Controller
    {
        private readonly IMediator _mediator;
        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllSubscriptionQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllSubscriptionDTO>>(response, true, "All Subscription Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string SubscriptionId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(SubscriptionId) && Guid.TryParse(SubscriptionId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetSubscriptionByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetSubscriptionByIdDTO>(response, true, "Subscription Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddSubscription([FromBody] CreateSubscriptionCommand Subscription)
        {
            try
            {
                if (Subscription is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Subscription);

                var successApiResponse = new SuccessAPIResponse<CreateSubscriptionCommandDTO>(response, true, "Subscription Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSubscription([FromBody] UpdateSubscriptionCommand Subscription)
        {
            try
            {
                if (Subscription is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Subscription);

                var successApiResponse = new SuccessAPIResponse<UpdateSubscriptionCommandDTO>(response, true, "Subscription Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteSubscription([FromQuery] string SubscriptionID)
        {
            try
            {
                if (SubscriptionID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(SubscriptionID, out Guid SubscriptionGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid Subscription ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteSubscriptionCommand Subscription = new DeleteSubscriptionCommand
                {
                    Id = SubscriptionGuid
                };

                var response = await _mediator.Send(Subscription);

                var successApiResponse = new SuccessAPIResponse<DeleteSubscriptionCommandDTO>(response, true, "Subscription Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
