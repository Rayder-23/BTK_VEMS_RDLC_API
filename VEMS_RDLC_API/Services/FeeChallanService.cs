using Microsoft.Reporting.NETCore;
using VEMS.PrintEngine.Repositories;

namespace VEMS.PrintEngine.Services
{
    public class FeeChallanService : IFeeChallanService
    {
        private readonly IFeeChallanRepository _challanRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FeeChallanService(IFeeChallanRepository challanRepository, IWebHostEnvironment webHostEnvironment)
        {
            _challanRepository = challanRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<byte[]> GenerateChallanPdfAsync(string challanNo)
        {
            var challanData = await _challanRepository.GetChallanPrintDataAsync(challanNo);
            
            if (challanData == null || !challanData.Any())
            {
                throw new KeyNotFoundException($"No data records found for Challan No: {challanNo}");
            }

            string reportPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "FeeChallan.rdlc");
            
            if (!File.Exists(reportPath))
            {
                throw new FileNotFoundException($"RDLC template missing at location: {reportPath}");
            }

            LocalReport report = new LocalReport();
            using var fs = new FileStream(reportPath, FileMode.Open, FileAccess.Read);
            report.LoadReportDefinition(fs);

            // Bind explicitly to the layout datasource name
            report.DataSources.Add(new ReportDataSource("VoucherDataset", challanData));
            
            return report.Render("PDF");
        }
    }
}