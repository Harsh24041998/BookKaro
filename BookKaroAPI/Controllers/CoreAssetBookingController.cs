using BookKaroAPI.Response;
using Bussiness.Features.CoreAssetBooking.Commands.CreateCoreAssetBookingCommand;
using Bussiness.Features.CoreAssetBooking.Commands.DeleteCoreAssetBookingCommand;
using Bussiness.Features.CoreAssetBooking.Commands.UpdateCoreAssetBookingCommand;
using Bussiness.Features.CoreAssetBooking.Queries.GetAllCoreAssetBookingQuery;
using Bussiness.Features.CoreAssetBooking.Queries.GetCoreAssetBookingByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreAssetBookingController : Controller
    {
        private readonly IMediator _mediator;
        public CoreAssetBookingController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllCoreAssetBookingQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllCoreAssetBookingQueryDTO>>(response, true, "All CoreAssetBooking Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string CoreAssetBookingId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(CoreAssetBookingId) && Guid.TryParse(CoreAssetBookingId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetCoreAssetBookingByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetCoreAssetBookingByIdDTO>(response, true, "CoreAssetBooking Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCoreAssetBooking([FromBody] CreateCoreAssetBookingCommand CoreAssetBooking)
        {
            try
            {
                if (CoreAssetBooking is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetBooking);

                var successApiResponse = new SuccessAPIResponse<CreateCoreAssetBookingCommandDTO>(response, true, "CoreAssetBooking Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCoreAssetBooking([FromBody] UpdateCoreAssetBookingCommand CoreAssetBooking)
        {
            try
            {
                if (CoreAssetBooking is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetBooking);

                var successApiResponse = new SuccessAPIResponse<UpdateCoreAssetBookingCommandDTO>(response, true, "CoreAssetBooking Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCoreAssetBooking([FromQuery] string CoreAssetBookingID)
        {
            try
            {
                if (CoreAssetBookingID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(CoreAssetBookingID, out Guid CoreAssetBookingGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid CoreAssetBooking ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteCoreAssetBookingCommand CoreAssetBooking = new DeleteCoreAssetBookingCommand
                {
                    Id = CoreAssetBookingGuid
                };

                var response = await _mediator.Send(CoreAssetBooking);

                var successApiResponse = new SuccessAPIResponse<DeleteCoreAssetBookingCommandDTO>(response, true, "CoreAssetBooking Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
