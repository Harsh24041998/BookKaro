using BookKaroAPI.Response;
using Bussiness.Features.Industry.Commands.CreateIndustryCommand;
using Bussiness.Features.Industry.Commands.DeleteIndustryCommand;
using Bussiness.Features.Industry.Commands.UpdateIndustryCommand;
using Bussiness.Features.Industry.Queries.GetAllIndustryQuery;
using Bussiness.Features.Industry.Queries.GetIndustryByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustryController : Controller
    {
        private readonly IMediator _mediator;
        public IndustryController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllIndustryQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllIndustryDTO>>(response, true, "All Industry Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string industryId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(industryId) && Guid.TryParse(industryId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetIndustryByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetIndustryByIdDTO>(response, true, "Industry Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddIndustry([FromBody] CreateIndustryCommand Industry)
        {
            try
            {
                if (Industry is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Industry);

                var successApiResponse = new SuccessAPIResponse<CreateIndustryCommandDTO>(response, true, "Industry Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateIndustry([FromBody] UpdateIndustryCommand Industry)
        {
            try
            {
                if (Industry is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Industry);

                var successApiResponse = new SuccessAPIResponse<UpdateIndustryCommandDTO>(response, true, "Industry Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteIndustry([FromQuery] string industryID)
        {
            try
            {
                if (industryID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(industryID, out Guid IndustryGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid Industry ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteIndustryCommand Industry = new DeleteIndustryCommand
                {
                    Id = IndustryGuid
                };

                var response = await _mediator.Send(Industry);

                var successApiResponse = new SuccessAPIResponse<DeleteIndustryCommandDTO>(response, true, "Industry Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
