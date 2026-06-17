using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VEMS.PrintEngine.Data;
using VEMS.PrintEngine.Models;
using VEMS.PrintEngine.Services;

namespace VEMS.PrintEngine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeeVoucherController : ControllerBase
    {
        private readonly IFeeVoucherService _voucherService;
        private readonly VemsDbContext _context;

        public FeeVoucherController(IFeeVoucherService voucherService, VemsDbContext context)
        {
            _voucherService = voucherService;
            _context = context;
        }

        [HttpGet("print/{voucherNo}")]
        public async Task<IActionResult> PrintVoucher(string voucherNo)
        {
            var data = await GetVoucherDataAsync(voucherNo);
            
            if (data == null || !data.Any())
                return NotFound($"Voucher {voucherNo} not found in the database.");

            // Render the live database data directly to your PDF engine
            byte[] pdfBytes = _voucherService.GenerateVoucherPdf(data);
            return File(pdfBytes, "application/pdf", $"Voucher_{voucherNo}.pdf");
        }

        [HttpGet("test-data/{voucherNo}")]
        public async Task<IActionResult> TestVoucherData(string voucherNo)
        {
            try
            {
                var dbData = await GetVoucherDataAsync(voucherNo);
                
                if (dbData == null || !dbData.Any())
                {
                    return Ok(new {
                        Source = "Mock Data (Database returned 0 rows for this Voucher Number)",
                        Data = new List<FeeVoucherReportModel>
                        {
                            new() { VoucherNo = voucherNo, StudentId = "REG-1024", StudentName = "Zayn Ahmed", ClassName = "Semester 3", TermOrMonth = "June", IssueDate = "17-Jun-2026", DueDate = "30-Jun-2026", FeeHeadName = "Tuition Fee", Amount = 45000, TotalAmount = 47500, Status = "Unpaid" },
                            new() { VoucherNo = voucherNo, StudentId = "REG-1024", StudentName = "Zayn Ahmed", ClassName = "Semester 3", TermOrMonth = "June", IssueDate = "17-Jun-2026", DueDate = "30-Jun-2026", FeeHeadName = "Lab Fee", Amount = 2500, TotalAmount = 47500, Status = "Unpaid" }
                        }
                    });
                }

                return Ok(new {
                    Source = "Live Database Connection",
                    RowCount = dbData.Count,
                    Data = dbData
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message, Inner = ex.InnerException?.Message });
            }
        }

        // Helper method cleanly scoped inside the controller class
        private async Task<List<FeeVoucherReportModel>> GetVoucherDataAsync(string challanNo)
        {
            string query = @"
                SELECT 
                    c.ChallanNo AS VoucherNo, s.RegistrationNo AS StudentId, s.StudentName,
                    c.Semester AS ClassName, c.ChallanMonth AS TermOrMonth,
                    FORMAT(c.IssueDate, 'dd-MMM-yyyy') AS IssueDate, FORMAT(c.DueDate, 'dd-MMM-yyyy') AS DueDate,
                    fh.HeadName AS FeeHeadName, cd.NetAmount AS Amount, c.NetPayable AS TotalAmount, c.Status
                FROM dbo.Challans c
                INNER JOIN dbo.Students s ON c.StudentID = s.StudentID
                INNER JOIN dbo.ChallanDetails cd ON c.Uid = cd.ChallanID
                INNER JOIN dbo.ref_FeeHeads fh ON cd.FeeHeadID = fh.Uid
                WHERE c.ChallanNo = {0} AND c.IsActive = 1";

            return await _context.Database
                .SqlQueryRaw<FeeVoucherReportModel>(query, challanNo)
                .ToListAsync();
        }
    }
}