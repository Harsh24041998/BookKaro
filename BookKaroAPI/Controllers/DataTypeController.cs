using BookKaroAPI.Response;
using Bussiness.Features.DataType.Commands.CreateDataTypeCommand;
using Bussiness.Features.DataType.Commands.DeleteDataTypeCommand;
using Bussiness.Features.DataType.Commands.UpdateDataTypeCommand;
using Bussiness.Features.DataType.Queries.GetAllDataTypeQuery;
using Bussiness.Features.DataType.Queries.GetDataTypeByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTypeController : Controller
    {
        private readonly IMediator _mediator;
        public DataTypeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllDataTypeQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllDataTypeDTO>>(response, true, "All DataType Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string dataTypeId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(dataTypeId) && Guid.TryParse(dataTypeId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetDataTypeByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetDataTypeByIdDTO>(response, true, "DataType Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddDataType([FromBody] CreateDataTypeCommand DataType)
        {
            try
            {
                if (DataType is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(DataType);

                var successApiResponse = new SuccessAPIResponse<CreateDataTypeCommandDTO>(response, true, "DataType Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDataType([FromBody] UpdateDataTypeCommand DataType)
        {
            try
            {
                if (DataType is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(DataType);

                var successApiResponse = new SuccessAPIResponse<UpdateDataTypeCommandDTO>(response, true, "DataType Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteDataType([FromQuery] string dataTypeID)
        {
            try
            {
                if (dataTypeID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(dataTypeID, out Guid DataTypeGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid DataType ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteDataTypeCommand DataType = new DeleteDataTypeCommand
                {
                    Id = DataTypeGuid
                };

                var response = await _mediator.Send(DataType);

                var successApiResponse = new SuccessAPIResponse<DeleteDataTypeCommandDTO>(response, true, "DataType Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
