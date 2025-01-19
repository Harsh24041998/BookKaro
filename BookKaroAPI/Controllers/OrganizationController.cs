using BookKaroAPI.Response;
using Bussiness.Features.Organization.Commands.CreateOrganizationCommand;
using Bussiness.Features.Organization.Commands.DeleteOrganizationCommand;
using Bussiness.Features.Organization.Commands.UpdateOrganizationCommand;
using Bussiness.Features.Organization.Queries.GetAllOrganizationQuery;
using Bussiness.Features.Organization.Queries.GetOrganizationByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : Controller
    {
        private readonly IMediator _mediator;
        public OrganizationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllOrganizationQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllOrganizationDTO>>(response, true, "All Organization Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string organizationId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(organizationId) && Guid.TryParse(organizationId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetOrganizationByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetOrganizationByIdDTO>(response, true, "Organization Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddOrganization([FromBody] CreateOrganizationCommand Organization)
        {
            try
            {
                if (Organization is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Organization);

                var successApiResponse = new SuccessAPIResponse<CreateOrganizationCommandDTO>(response, true, "Organization Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateOrganization([FromBody] UpdateOrganizationCommand Organization)
        {
            try
            {
                if (Organization is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Organization);

                var successApiResponse = new SuccessAPIResponse<UpdateOrganizationCommandDTO>(response, true, "Organization Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteOrganization([FromQuery] string organizationID)
        {
            try
            {
                if (organizationID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(organizationID, out Guid OrganizationGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid Organization ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteOrganizationCommand Organization = new DeleteOrganizationCommand
                {
                    Id = OrganizationGuid
                };

                var response = await _mediator.Send(Organization);

                var successApiResponse = new SuccessAPIResponse<DeleteOrganizationCommandDTO>(response, true, "Organization Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
