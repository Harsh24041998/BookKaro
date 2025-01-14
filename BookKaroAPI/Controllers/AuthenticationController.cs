using BookKaroAPI.Response;
using Bussiness.Features.Authentication.SendOTP;
using Bussiness.Features.Authentication.VerifyOTP;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookKaroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost("SendOTP")]
        public async Task<IActionResult> Login([FromBody] SendOTPCommand request)
        {
            try
            {
                // Delegate login logic to MediatR handler
                var sendOTP = await _mediator.Send(request);

                var successApiResponse = new SuccessAPIResponse<SendOTPCommandDTO>(sendOTP, true, "OTP send Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("VerifyOTP")]
        public async Task<IActionResult> Login([FromBody] VerifyOTPCommand request)
        {
            try
            {
                // Delegate login logic to MediatR handler
                var verifyOTP = await _mediator.Send(request);

                var successApiResponse = new SuccessAPIResponse<VerifyOTPCommandDTO>(verifyOTP, true, "OTP Verified Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
