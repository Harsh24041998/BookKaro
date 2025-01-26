using BookKaroAPI.Response;
using Bussiness.Features.CoreAssetTemplate.Commands.CreateCoreAssetTemplateCommand;
using Bussiness.Features.CoreAssetTemplate.Commands.DeleteCoreAssetTemplateCommand;
using Bussiness.Features.CoreAssetTemplate.Commands.UpdateCoreAssetTemplateCommand;
using Bussiness.Features.CoreAssetTemplate.Queries.GetAllCoreAssetTemplateQuery;
using Bussiness.Features.CoreAssetTemplate.Queries.GetCoreAssetTemplateByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreAssetTemplateController : Controller
    {
        private readonly IMediator _mediator;
        public CoreAssetTemplateController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllCoreAssetTemplateQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllCoreAssetTemplateDTO>>(response, true, "All CoreAssetTemplate Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string CoreAssetTemplateId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(CoreAssetTemplateId) && Guid.TryParse(CoreAssetTemplateId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetCoreAssetTemplateByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetCoreAssetTemplateByIdDTO>(response, true, "CoreAssetTemplate Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCoreAssetTemplate([FromBody] CreateCoreAssetTemplateCommand CoreAssetTemplate)
        {
            try
            {
                if (CoreAssetTemplate is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetTemplate);

                var successApiResponse = new SuccessAPIResponse<CreateCoreAssetTemplateCommandDTO>(response, true, "CoreAssetTemplate Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCoreAssetTemplate([FromBody] UpdateCoreAssetTemplateCommand CoreAssetTemplate)
        {
            try
            {
                if (CoreAssetTemplate is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetTemplate);

                var successApiResponse = new SuccessAPIResponse<UpdateCoreAssetTemplateCommandDTO>(response, true, "CoreAssetTemplate Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCoreAssetTemplate([FromQuery] string CoreAssetTemplateID)
        {
            try
            {
                if (CoreAssetTemplateID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(CoreAssetTemplateID, out Guid CoreAssetTemplateGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid CoreAssetTemplate ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteCoreAssetTemplateCommand CoreAssetTemplate = new DeleteCoreAssetTemplateCommand
                {
                    Id = CoreAssetTemplateGuid
                };

                var response = await _mediator.Send(CoreAssetTemplate);

                var successApiResponse = new SuccessAPIResponse<DeleteCoreAssetTemplateCommandDTO>(response, true, "CoreAssetTemplate Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
