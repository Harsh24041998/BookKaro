using BookKaroAPI.Response;
using Bussiness.Features.Category.Commands.CreateCategoryCommand;
using Bussiness.Features.Category.Commands.DeleteCategoryCommand;
using Bussiness.Features.Category.Commands.UpdateCategoryCommand;
using Bussiness.Features.Category.Queries.GetAllCategoryQuery;
using Bussiness.Features.Category.Queries.GetCategoryByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllCategoryQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllCategoryDTO>>(response, true, "All Category Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string CategoryId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(CategoryId) && Guid.TryParse(CategoryId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetCategoryByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetCategoryByIdDTO>(response, true, "Category Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryCommand Category)
        {
            try
            {
                if (Category is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Category);

                var successApiResponse = new SuccessAPIResponse<CreateCategoryCommandDTO>(response, true, "Category Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand Category)
        {
            try
            {
                if (Category is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Category);

                var successApiResponse = new SuccessAPIResponse<UpdateCategoryCommandDTO>(response, true, "Category Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCategory([FromQuery] string CategoryID)
        {
            try
            {
                if (CategoryID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(CategoryID, out Guid CategoryGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid Category ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteCategoryCommand Category = new DeleteCategoryCommand
                {
                    Id = CategoryGuid
                };

                var response = await _mediator.Send(Category);

                var successApiResponse = new SuccessAPIResponse<DeleteCategoryCommandDTO>(response, true, "Category Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
