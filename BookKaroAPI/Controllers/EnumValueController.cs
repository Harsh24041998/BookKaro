using BookKaroAPI.Response;
using Bussiness.Features.EnumValue.Commands.CreateEnumValueCommand;
using Bussiness.Features.EnumValue.Commands.DeleteEnumValueCommand;
using Bussiness.Features.EnumValue.Commands.UpdateEnumValueCommand;
using Bussiness.Features.EnumValue.Queries.GetAllEnumValueQuery;
using Bussiness.Features.EnumValue.Queries.GetEnumValueByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumValueController : Controller
    {
        private readonly IMediator _mediator;
        public EnumValueController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllEnumValueQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllEnumValueDTO>>(response, true, "All EnumValue Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string EnumValueId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(EnumValueId) && Guid.TryParse(EnumValueId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetEnumValueByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetEnumValueByIdDTO>(response, true, "EnumValue Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddEnumValue([FromBody] CreateEnumValueCommand EnumValue)
        {
            try
            {
                if (EnumValue is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(EnumValue);

                var successApiResponse = new SuccessAPIResponse<CreateEnumValueCommandDTO>(response, true, "EnumValue Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEnumValue([FromBody] UpdateEnumValueCommand EnumValue)
        {
            try
            {
                if (EnumValue is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(EnumValue);

                var successApiResponse = new SuccessAPIResponse<UpdateEnumValueCommandDTO>(response, true, "EnumValue Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEnumValue([FromQuery] string EnumValueID)
        {
            try
            {
                if (EnumValueID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(EnumValueID, out Guid EnumValueGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid EnumValue ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteEnumValueCommand EnumValue = new DeleteEnumValueCommand
                {
                    Id = EnumValueGuid
                };

                var response = await _mediator.Send(EnumValue);

                var successApiResponse = new SuccessAPIResponse<DeleteEnumValueCommandDTO>(response, true, "EnumValue Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
