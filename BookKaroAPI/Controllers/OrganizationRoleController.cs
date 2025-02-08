using BookKaroAPI.Response;
using Bussiness.Features.OrganizationRole.Commands.CreateOrganizationRoleCommand;
using Bussiness.Features.OrganizationRole.Commands.DeleteOrganizationRoleCommand;
using Bussiness.Features.OrganizationRole.Commands.UpdateOrganizationRoleCommand;
using Bussiness.Features.OrganizationRole.Queries.GetAllOrganizationRoleQuery;
using Bussiness.Features.OrganizationRole.Queries.GetOrganizationRoleByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationRoleController : Controller
    {
        private readonly IMediator _mediator;
        public OrganizationRoleController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllOrganizationRoleQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllOrganizationRoleDTO>>(response, true, "All OrganizationRole Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string OrganizationRoleId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(OrganizationRoleId) && Guid.TryParse(OrganizationRoleId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetOrganizationRoleByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetOrganizationRoleByIdDTO>(response, true, "OrganizationRole Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddOrganizationRole([FromBody] CreateOrganizationRoleCommand OrganizationRole)
        {
            try
            {
                if (OrganizationRole is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(OrganizationRole);

                var successApiResponse = new SuccessAPIResponse<CreateOrganizationRoleCommandDTO>(response, true, "OrganizationRole Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateOrganizationRole([FromBody] UpdateOrganizationRoleCommand OrganizationRole)
        {
            try
            {
                if (OrganizationRole is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(OrganizationRole);

                var successApiResponse = new SuccessAPIResponse<UpdateOrganizationRoleCommandDTO>(response, true, "OrganizationRole Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteOrganizationRole([FromQuery] string OrganizationRoleID)
        {
            try
            {
                if (OrganizationRoleID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(OrganizationRoleID, out Guid OrganizationRoleGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid OrganizationRole ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteOrganizationRoleCommand OrganizationRole = new DeleteOrganizationRoleCommand
                {
                    Id = OrganizationRoleGuid
                };

                var response = await _mediator.Send(OrganizationRole);

                var successApiResponse = new SuccessAPIResponse<DeleteOrganizationRoleCommandDTO>(response, true, "OrganizationRole Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
