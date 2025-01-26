using BookKaroAPI.Response;
using Bussiness.Features.CoreAssetCustomTemplate.Commands.CreateCoreAssetCustomTemplateCommand;
using Bussiness.Features.CoreAssetCustomTemplate.Commands.DeleteCoreAssetCustomTemplateCommand;
using Bussiness.Features.CoreAssetCustomTemplate.Commands.UpdateCoreAssetCustomTemplateCommand;
using Bussiness.Features.CoreAssetCustomTemplate.Queries.GetAllCoreAssetCustomTemplateQuery;
using Bussiness.Features.CoreAssetCustomTemplate.Queries.GetCoreAssetCustomTemplateByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreAssetCustomTemplateController : Controller
    {
        private readonly IMediator _mediator;
        public CoreAssetCustomTemplateController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllCoreAssetCustomTemplateQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllCoreAssetCustomTemplateDTO>>(response, true, "All CoreAssetCustomTemplate Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string CoreAssetCustomTemplateId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(CoreAssetCustomTemplateId) && Guid.TryParse(CoreAssetCustomTemplateId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetCoreAssetCustomTemplateByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetCoreAssetCustomTemplateByIdDTO>(response, true, "CoreAssetCustomTemplate Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCoreAssetCustomTemplate([FromBody] CreateCoreAssetCustomTemplateCommand CoreAssetCustomTemplate)
        {
            try
            {
                if (CoreAssetCustomTemplate is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetCustomTemplate);

                var successApiResponse = new SuccessAPIResponse<CreateCoreAssetCustomTemplateCommandDTO>(response, true, "CoreAssetCustomTemplate Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCoreAssetCustomTemplate([FromBody] UpdateCoreAssetCustomTemplateCommand CoreAssetCustomTemplate)
        {
            try
            {
                if (CoreAssetCustomTemplate is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetCustomTemplate);

                var successApiResponse = new SuccessAPIResponse<UpdateCoreAssetCustomTemplateCommandDTO>(response, true, "CoreAssetCustomTemplate Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCoreAssetCustomTemplate([FromQuery] string CoreAssetCustomTemplateID)
        {
            try
            {
                if (CoreAssetCustomTemplateID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(CoreAssetCustomTemplateID, out Guid CoreAssetCustomTemplateGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid CoreAssetCustomTemplate ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteCoreAssetCustomTemplateCommand CoreAssetCustomTemplate = new DeleteCoreAssetCustomTemplateCommand
                {
                    Id = CoreAssetCustomTemplateGuid
                };

                var response = await _mediator.Send(CoreAssetCustomTemplate);

                var successApiResponse = new SuccessAPIResponse<DeleteCoreAssetCustomTemplateCommandDTO>(response, true, "CoreAssetCustomTemplate Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
