using BookKaroAPI.Response;
using Bussiness.Features.EnumType.Commands.CreateEnumTypeCommand;
using Bussiness.Features.EnumType.Commands.DeleteEnumTypeCommand;
using Bussiness.Features.EnumType.Commands.UpdateEnumTypeCommand;
using Bussiness.Features.EnumType.Queries.GetAllEnumTypeQuery;
using Bussiness.Features.EnumType.Queries.GetEnumTypeByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumTypeController : Controller
    {
        private readonly IMediator _mediator;
        public EnumTypeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllEnumTypeQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllEnumTypeDTO>>(response, true, "All EnumType Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string EnumTypeId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(EnumTypeId) && Guid.TryParse(EnumTypeId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetEnumTypeByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetEnumTypeByIdDTO>(response, true, "EnumType Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddEnumType([FromBody] CreateEnumTypeCommand EnumType)
        {
            try
            {
                if (EnumType is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(EnumType);

                var successApiResponse = new SuccessAPIResponse<CreateEnumTypeCommandDTO>(response, true, "EnumType Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEnumType([FromBody] UpdateEnumTypeCommand EnumType)
        {
            try
            {
                if (EnumType is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(EnumType);

                var successApiResponse = new SuccessAPIResponse<UpdateEnumTypeCommandDTO>(response, true, "EnumType Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEnumType([FromQuery] string EnumTypeID)
        {
            try
            {
                if (EnumTypeID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(EnumTypeID, out Guid EnumTypeGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid EnumType ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteEnumTypeCommand EnumType = new DeleteEnumTypeCommand
                {
                    Id = EnumTypeGuid
                };

                var response = await _mediator.Send(EnumType);

                var successApiResponse = new SuccessAPIResponse<DeleteEnumTypeCommandDTO>(response, true, "EnumType Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
