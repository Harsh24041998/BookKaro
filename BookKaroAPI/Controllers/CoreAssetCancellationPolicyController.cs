using BookKaroAPI.Response;
using Bussiness.Features.CoreAssetCancellationPolicy.Commands.CreateCoreAssetCancellationPolicyCommand;
using Bussiness.Features.CoreAssetCancellationPolicy.Commands.DeleteCoreAssetCancellationPolicyCommand;
using Bussiness.Features.CoreAssetCancellationPolicy.Commands.UpdateCoreAssetCancellationPolicyCommand;
using Bussiness.Features.CoreAssetCancellationPolicy.Queries.GetAllCoreAssetCancellationPolicyQuery;
using Bussiness.Features.CoreAssetCancellationPolicy.Queries.GetCoreAssetCancellationPolicyByIdQuery;
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
    public class CoreAssetCancellationPolicyController : Controller
    {
        private readonly IMediator _mediator;
        public CoreAssetCancellationPolicyController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllCoreAssetCancellationPolicyQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllCoreAssetCancellationPolicyDTO>>(response, true, "All CoreAssetCancellationPolicy Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string CoreAssetCancellationPolicyId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(CoreAssetCancellationPolicyId) && Guid.TryParse(CoreAssetCancellationPolicyId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetCoreAssetCancellationPolicyByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetCoreAssetCancellationPolicyByIdDTO>(response, true, "CoreAssetCancellationPolicy Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCoreAssetCancellationPolicy([FromBody] CreateCoreAssetCancellationPolicyCommand CoreAssetCancellationPolicy)
        {
            try
            {
                if (CoreAssetCancellationPolicy is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetCancellationPolicy);

                var successApiResponse = new SuccessAPIResponse<CreateCoreAssetCancellationPolicyCommandDTO>(response, true, "CoreAssetCancellationPolicy Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCoreAssetCancellationPolicy([FromBody] UpdateCoreAssetCancellationPolicyCommand CoreAssetCancellationPolicy)
        {
            try
            {
                if (CoreAssetCancellationPolicy is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAssetCancellationPolicy);

                var successApiResponse = new SuccessAPIResponse<UpdateCoreAssetCancellationPolicyCommandDTO>(response, true, "CoreAssetCancellationPolicy Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCoreAssetCancellationPolicy([FromQuery] string CoreAssetCancellationPolicyID)
        {
            try
            {
                if (CoreAssetCancellationPolicyID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(CoreAssetCancellationPolicyID, out Guid CoreAssetCancellationPolicyGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid CoreAssetCancellationPolicy ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteCoreAssetCancellationPolicyCommand CoreAssetCancellationPolicy = new DeleteCoreAssetCancellationPolicyCommand
                {
                    Id = CoreAssetCancellationPolicyGuid
                };

                var response = await _mediator.Send(CoreAssetCancellationPolicy);

                var successApiResponse = new SuccessAPIResponse<DeleteCoreAssetCancellationPolicyCommandDTO>(response, true, "CoreAssetCancellationPolicy Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
