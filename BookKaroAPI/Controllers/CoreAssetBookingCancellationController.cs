using BookKaroAPI.Response;
using Bussiness.Features.CoreAssetBookingCancellation.Commands.CreateCoreAssetBookingCancellationCommand;
using Bussiness.Features.CoreAssetBookingCancellation.Commands.DeleteCoreAssetBookingCancellationCommand;
using Bussiness.Features.CoreAssetBookingCancellation.Commands.UpdateCoreAssetBookingCancellationCommand;
using Bussiness.Features.CoreAssetBookingCancellation.Queries.GetAllCoreAssetBookingCancellationQuery;
using Bussiness.Features.CoreAssetBookingCancellation.Queries.GetCoreAssetBookingCancellationByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreAssetBookingCancellationController : Controller
    {
        private readonly IMediator _mediator;
        public CoreAssetBookingCancellationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllCoreAssetBookingCancellationQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllCoreAssetBookingCancellationQueryDTO>>(response, true, "All CoreAssetBookingCancellation Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string CoreAssetBookingCancellationId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(CoreAssetBookingCancellationId) && Guid.TryParse(CoreAssetBookingCancellationId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetCoreAssetBookingCancellationByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetCoreAssetBookingCancellationByIdDTO>(response, true, "CoreAssetBookingCancellation Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCoreAssetBookingCancellation([FromBody] CreateCoreAssetBookingCancellationCommand CoreAssetBookingCancellation)
        {
            try
            {
                if (CoreAssetBookingCancellation is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetBookingCancellation);

                var successApiResponse = new SuccessAPIResponse<CreateCoreAssetBookingCancellationCommandDTO>(response, true, "CoreAssetBookingCancellation Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCoreAssetBookingCancellation([FromBody] UpdateCoreAssetBookingCancellationCommand CoreAssetBookingCancellation)
        {
            try
            {
                if (CoreAssetBookingCancellation is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetBookingCancellation);

                var successApiResponse = new SuccessAPIResponse<UpdateCoreAssetBookingCancellationCommandDTO>(response, true, "CoreAssetBookingCancellation Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCoreAssetBookingCancellation([FromQuery] string CoreAssetBookingCancellationID)
        {
            try
            {
                if (CoreAssetBookingCancellationID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(CoreAssetBookingCancellationID, out Guid CoreAssetBookingCancellationGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid CoreAssetBookingCancellation ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteCoreAssetBookingCancellationCommand CoreAssetBookingCancellation = new DeleteCoreAssetBookingCancellationCommand
                {
                    Id = CoreAssetBookingCancellationGuid
                };

                var response = await _mediator.Send(CoreAssetBookingCancellation);

                var successApiResponse = new SuccessAPIResponse<DeleteCoreAssetBookingCancellationCommandDTO>(response, true, "CoreAssetBookingCancellation Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
