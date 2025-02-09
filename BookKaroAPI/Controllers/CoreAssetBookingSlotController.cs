using BookKaroAPI.Response;
using Bussiness.Features.CoreAssetBookingSlot.Commands.CreateCoreAssetBookingSlotCommand;
using Bussiness.Features.CoreAssetBookingSlot.Commands.DeleteCoreAssetBookingSlotCommand;
using Bussiness.Features.CoreAssetBookingSlot.Commands.UpdateCoreAssetBookingSlotCommand;
using Bussiness.Features.CoreAssetBookingSlot.Queries.GetAllCoreAssetBookingSlotQuery;
using Bussiness.Features.CoreAssetBookingSlot.Queries.GetCoreAssetBookingSlotByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreAssetBookingSlotController : Controller
    {
        private readonly IMediator _mediator;
        public CoreAssetBookingSlotController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllCoreAssetBookingSlotQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllCoreAssetBookingSlotQueryDTO>>(response, true, "All CoreAssetBookingSlot Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string coreAssetBookingSlotId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(coreAssetBookingSlotId) && Guid.TryParse(coreAssetBookingSlotId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetCoreAssetBookingSlotByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetCoreAssetBookingSlotByIdDTO>(response, true, "CoreAssetBookingSlot Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCoreAssetBookingSlot([FromBody] CreateCoreAssetBookingSlotCommand CoreAssetBookingSlot)
        {
            try
            {
                if (CoreAssetBookingSlot is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetBookingSlot);

                var successApiResponse = new SuccessAPIResponse<CreateCoreAssetBookingSlotCommandDTO>(response, true, "CoreAssetBookingSlot Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCoreAssetBookingSlot([FromBody] UpdateCoreAssetBookingSlotCommand CoreAssetBookingSlot)
        {
            try
            {
                if (CoreAssetBookingSlot is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetBookingSlot);

                var successApiResponse = new SuccessAPIResponse<UpdateCoreAssetBookingSlotCommandDTO>(response, true, "CoreAssetBookingSlot Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCoreAssetBookingSlot([FromQuery] string coreAssetBookingSlotID)
        {
            try
            {
                if (coreAssetBookingSlotID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(coreAssetBookingSlotID, out Guid CoreAssetBookingSlotGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid CoreAssetBookingSlot ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteCoreAssetBookingSlotCommand CoreAssetBookingSlot = new DeleteCoreAssetBookingSlotCommand
                {
                    Id = CoreAssetBookingSlotGuid
                };

                var response = await _mediator.Send(CoreAssetBookingSlot);

                var successApiResponse = new SuccessAPIResponse<DeleteCoreAssetBookingSlotCommandDTO>(response, true, "CoreAssetBookingSlot Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
