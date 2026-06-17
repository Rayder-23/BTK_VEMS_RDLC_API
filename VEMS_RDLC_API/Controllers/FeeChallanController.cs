using Microsoft.AspNetCore.Mvc;
using VEMS.PrintEngine.Services;

namespace VEMS.PrintEngine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeeChallanController : ControllerBase
    {
        private readonly IFeeChallanService _challanService;

        public FeeChallanController(IFeeChallanService challanService)
        {
            _challanService = challanService;
        }

        [HttpGet("print/{challanNo}")]
        public async Task<IActionResult> PrintChallan(string challanNo)
        {
            try
            {
                byte[] pdfBytes = await _challanService.GenerateChallanPdfAsync(challanNo);
                string fileName = $"FeeChallan_{challanNo}.pdf";
                return File(pdfBytes, "application/pdf", fileName);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during print processing.", details = ex.Message });
            }
        }
    }
}