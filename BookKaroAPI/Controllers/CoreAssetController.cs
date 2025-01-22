using BookKaroAPI.Response;
using Bussiness.Features.CoreAsset.Commands.CreateCoreAssetCommand;
using Bussiness.Features.CoreAsset.Commands.DeleteCoreAssetCommand;
using Bussiness.Features.CoreAsset.Commands.UpdateCoreAssetCommand;
using Bussiness.Features.CoreAsset.Queries.GetAllCoreAssetQuery;
using Bussiness.Features.CoreAsset.Queries.GetCoreAssetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreAssetController : Controller
    {
        private readonly IMediator _mediator;
        public CoreAssetController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllCoreAssetQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllCoreAssetDTO>>(response, true, "All CoreAsset Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string coreAssetId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(coreAssetId) && Guid.TryParse(coreAssetId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetCoreAssetByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetCoreAssetByIdDTO>(response, true, "CoreAsset Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCoreAsset([FromBody] CreateCoreAssetCommand CoreAsset)
        {
            try
            {
                if (CoreAsset is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAsset);

                var successApiResponse = new SuccessAPIResponse<CreateCoreAssetCommandDTO>(response, true, "CoreAsset Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCoreAsset([FromBody] UpdateCoreAssetCommand CoreAsset)
        {
            try
            {
                if (CoreAsset is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(CoreAsset);

                var successApiResponse = new SuccessAPIResponse<UpdateCoreAssetCommandDTO>(response, true, "CoreAsset Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCoreAsset([FromQuery] string coreAssetID)
        {
            try
            {
                if (coreAssetID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(coreAssetID, out Guid CoreAssetGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid CoreAsset ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteCoreAssetCommand CoreAsset = new DeleteCoreAssetCommand
                {
                    Id = CoreAssetGuid
                };

                var response = await _mediator.Send(CoreAsset);

                var successApiResponse = new SuccessAPIResponse<DeleteCoreAssetCommandDTO>(response, true, "CoreAsset Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
