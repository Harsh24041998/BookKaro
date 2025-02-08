using BookKaroAPI.Response;
using Bussiness.Features.Address.Commands.CreateAddressCommand;
using Bussiness.Features.Address.Commands.DeleteAddressCommand;
using Bussiness.Features.Address.Commands.UpdateAddressCommand;
using Bussiness.Features.Address.Queries.GetAllAddressQuery;
using Bussiness.Features.Address.Queries.GetAddressByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllAddressQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllAddressDTO>>(response, true, "All Address Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string AddressId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(AddressId) && Guid.TryParse(AddressId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetAddressByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetAddressByIdDTO>(response, true, "Address Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAddress([FromBody] CreateAddressCommand Address)
        {
            try
            {
                if (Address is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Address);

                var successApiResponse = new SuccessAPIResponse<CreateAddressCommandDTO>(response, true, "Address Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommand Address)
        {
            try
            {
                if (Address is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Address);

                var successApiResponse = new SuccessAPIResponse<UpdateAddressCommandDTO>(response, true, "Address Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAddress([FromQuery] string AddressID)
        {
            try
            {
                if (AddressID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(AddressID, out Guid AddressGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid Address ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteAddressCommand Address = new DeleteAddressCommand
                {
                    Id = AddressGuid
                };

                var response = await _mediator.Send(Address);

                var successApiResponse = new SuccessAPIResponse<DeleteAddressCommandDTO>(response, true, "Address Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
