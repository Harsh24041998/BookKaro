using BookKaroAPI.Response;
using Bussiness.Features.Transaction.Commands.CreateTransactionCommand;
using Bussiness.Features.Transaction.Commands.DeleteTransactionCommand;
using Bussiness.Features.Transaction.Commands.UpdateTransactionCommand;
using Bussiness.Features.Transaction.Queries.GetTransactionByIdQuery;
using Bussiness.Features.Transaction.Queries.GetAllTransactionQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllTransactionQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllTransactionDTO>>(response, true, "All Transaction Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById([FromQuery] string TransactionId)
        {
            try
            {
                Guid? customerIdGuid = null;
                if (!string.IsNullOrEmpty(TransactionId) && Guid.TryParse(TransactionId, out Guid parsedGuid))
                {
                    customerIdGuid = parsedGuid;
                }

                var response = await _mediator.Send(new GetTransactionByIdQuery() { Id = customerIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetTransactionByIdDTO>(response, true, "Transaction Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddTransaction([FromBody] CreateTransactionCommand Transaction)
        {
            try
            {
                if (Transaction is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Transaction);

                var successApiResponse = new SuccessAPIResponse<CreateTransactionCommandDTO>(response, true, "Transaction Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTransaction([FromBody] UpdateTransactionCommand Transaction)
        {
            try
            {
                if (Transaction is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(Transaction);

                var successApiResponse = new SuccessAPIResponse<UpdateTransactionCommandDTO>(response, true, "Transaction Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteTransaction([FromQuery] string TransactionID)
        {
            try
            {
                if (TransactionID is null)
                    throw new ArgumentException("A non-empty request body is required.");

                // Convert string to Guid
                if (!Guid.TryParse(TransactionID, out Guid TransactionGuid))
                {
                    // Return a bad request response if the GUID is invalid
                    return BadRequest("Invalid Transaction ID.");
                }

                // Create the DeleteDepartmentCommand with the valid Guid
                DeleteTransactionCommand Transaction = new DeleteTransactionCommand
                {
                    Id = TransactionGuid
                };

                var response = await _mediator.Send(Transaction);

                var successApiResponse = new SuccessAPIResponse<DeleteTransactionCommandDTO>(response, true, "Transaction Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
