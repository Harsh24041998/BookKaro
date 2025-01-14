using BookKaroAPI.Response;
using Bussiness.Features.Gender.Commands.CreateGenderCommand;
using Bussiness.Features.Gender.Commands.DeleteGenderCommand;
using Bussiness.Features.Gender.Commands.UpdateGenderCommand;
using Bussiness.Features.Gender.Queries.GetAllGenderQuery;
using Bussiness.Features.Gender.Queries.GetGenderByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : Controller
    {
        private readonly IMediator _mediator;
        public GenderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllGenderQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllGenderDTO>>(response, true, "All Gender Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string genderId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(genderId) && Guid.TryParse(genderId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetGenderByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetGenderByIdDTO>(response, true, "Gender Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddGender([FromBody] CreateGenderCommand gender)
        {
            try
            {
                if (gender is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(gender);

                var successApiResponse = new SuccessAPIResponse<CreateGenderCommandDTO>(response, true, "Gender Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateGender([FromBody] UpdateGenderCommand gender)
        {
            try
            {
                if (gender is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(gender);

                var successApiResponse = new SuccessAPIResponse<UpdateGenderCommandDTO>(response, true, "Gender Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteGender([FromQuery] string genderID)
        {
            try
            {
                if (genderID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(genderID, out Guid GenderGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid Gender ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteGenderCommand Gender = new DeleteGenderCommand
                {
                    Id = GenderGuid
                };

                var response = await _mediator.Send(Gender);

                var successApiResponse = new SuccessAPIResponse<DeleteGenderCommandDTO>(response, true, "Gender Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
