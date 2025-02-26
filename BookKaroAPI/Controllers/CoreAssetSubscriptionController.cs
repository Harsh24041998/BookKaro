using BookKaroAPI.Response;
using Bussiness.Features.CoreAssetSubscription.Commands.CreateCoreAssetSubscriptionCommand;
using Bussiness.Features.CoreAssetSubscription.Commands.DeleteCoreAssetSubscriptionCommand;
using Bussiness.Features.CoreAssetSubscription.Commands.UpdateCoreAssetSubscriptionCommand;
using Bussiness.Features.CoreAssetSubscription.Queries.GetAllCoreAssetSubscriptionQuery;
using Bussiness.Features.CoreAssetSubscription.Queries.GetCoreAssetSubscriptionByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreAssetSubscriptionController : Controller
    {
        private readonly IMediator _mediator;
        public CoreAssetSubscriptionController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllCoreAssetSubscriptionQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllCoreAssetSubscriptionQueryDTO>>(response, true, "All CoreAssetSubscription Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string CoreAssetSubscriptionId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(CoreAssetSubscriptionId) && Guid.TryParse(CoreAssetSubscriptionId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetCoreAssetSubscriptionByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetCoreAssetSubscriptionByIdDTO>(response, true, "CoreAssetSubscription Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCoreAssetSubscription([FromBody] CreateCoreAssetSubscriptionCommand CoreAssetSubscription)
        {
            try
            {
                if (CoreAssetSubscription is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetSubscription);

                var successApiResponse = new SuccessAPIResponse<CreateCoreAssetSubscriptionCommandDTO>(response, true, "CoreAssetSubscription Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCoreAssetSubscription([FromBody] UpdateCoreAssetSubscriptionCommand CoreAssetSubscription)
        {
            try
            {
                if (CoreAssetSubscription is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetSubscription);

                var successApiResponse = new SuccessAPIResponse<UpdateCoreAssetSubscriptionCommandDTO>(response, true, "CoreAssetSubscription Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCoreAssetSubscription([FromQuery] string CoreAssetSubscriptionID)
        {
            try
            {
                if (CoreAssetSubscriptionID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(CoreAssetSubscriptionID, out Guid CoreAssetSubscriptionGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid CoreAssetSubscription ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteCoreAssetSubscriptionCommand CoreAssetSubscription = new DeleteCoreAssetSubscriptionCommand
                {
                    Id = CoreAssetSubscriptionGuid
                };

                var response = await _mediator.Send(CoreAssetSubscription);

                var successApiResponse = new SuccessAPIResponse<DeleteCoreAssetSubscriptionCommandDTO>(response, true, "CoreAssetSubscription Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
