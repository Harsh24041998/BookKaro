using BookKaroAPI.Response;
using Bussiness.Features.User.Commands.CreateUserCommand;
using Bussiness.Features.User.Commands.DeleteUserCommand;
using Bussiness.Features.User.Commands.UpdateUserCommand;
using Bussiness.Features.User.Queries.GetAllUserQuery;
using Bussiness.Features.User.Queries.GetUserByIdQuery;
using Bussiness.Features.User.Queries.GetUserByMobileNumberQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllUserQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllUserDTO>>(response, true, "All User Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string userId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(userId) && Guid.TryParse(userId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetUserByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetUserByIdDTO>(response, true, "User Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetByMobileNumber")]
        public async Task<IActionResult> GetByMobileNumber([FromQuery] string mobileNumber)
        {
            try
            {
              

                var response = await _mediator.Send(new GetUserByMobileNumberQuery() { MobileNumber = mobileNumber });

                var successApiResponse = new SuccessAPIResponse<GetUserByMobileNumberDTO>(response, true, "User Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddUser([FromBody] CreateUserCommand User)
        {
            try
            {
                if (User is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(User);

                var successApiResponse = new SuccessAPIResponse<CreateUserCommandDTO>(response, true, "User Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand User)
        {
            try
            {
                if (User is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(User);

                var successApiResponse = new SuccessAPIResponse<UpdateUserCommandDTO>(response, true, "User Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUser([FromQuery] string userID)
        {
            try
            {
                if (userID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(userID, out Guid UserGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid User ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteUserCommand User = new DeleteUserCommand
                {
                    Id = UserGuid
                };

                var response = await _mediator.Send(User);

                var successApiResponse = new SuccessAPIResponse<DeleteUserCommandDTO>(response, true, "User Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
