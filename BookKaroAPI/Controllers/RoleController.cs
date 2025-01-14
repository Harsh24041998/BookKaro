using BookKaroAPI.Response;
using Bussiness.Features.Role.Commands.CreateRoleCommand;
using Bussiness.Features.Role.Commands.DeleteRoleCommand;
using Bussiness.Features.Role.Commands.UpdateRoleCommand;
using Bussiness.Features.Role.Queries.GetAllRoleQuery;
using Bussiness.Features.Role.Queries.GetRoleByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllRoleQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllRoleDTO>>(response, true, "All Role Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string RoleId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(RoleId) && Guid.TryParse(RoleId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetRoleByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetRoleByIdDTO>(response, true, "Role Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddRole([FromBody] CreateRoleCommand Role)
        {
            try
            {
                if (Role is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Role);

                var successApiResponse = new SuccessAPIResponse<CreateRoleCommandDTO>(response, true, "Role Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand Role)
        {
            try
            {
                if (Role is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Role);

                var successApiResponse = new SuccessAPIResponse<UpdateRoleCommandDTO>(response, true, "Role Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteRole([FromQuery] string RoleID)
        {
            try
            {
                if (RoleID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(RoleID, out Guid RoleGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid Role ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteRoleCommand Role = new DeleteRoleCommand
                {
                    Id = RoleGuid
                };

                var response = await _mediator.Send(Role);

                var successApiResponse = new SuccessAPIResponse<DeleteRoleCommandDTO>(response, true, "Role Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
