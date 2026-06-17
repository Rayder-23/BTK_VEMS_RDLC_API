using Microsoft.Reporting.NETCore;
using System.Text;
using VEMS.PrintEngine.Models;

namespace VEMS.PrintEngine.Services
{
    public interface IFeeVoucherService
    {
        byte[] GenerateVoucherPdf(List<FeeVoucherReportModel> voucherData);
    }

    public class FeeVoucherService : IFeeVoucherService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FeeVoucherService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            // Registers code pages provider to ensure PDF fonts render cleanly without crashing
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public byte[] GenerateVoucherPdf(List<FeeVoucherReportModel> voucherData)
        {
            string reportPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "FeeChallan.rdlc");
            
            LocalReport report = new LocalReport();
            using var fs = new FileStream(reportPath, FileMode.Open, FileAccess.Read);
            report.LoadReportDefinition(fs);
            
            // "VoucherDataset" must match your RDLC data source name exactly later
            report.DataSources.Add(new ReportDataSource("VoucherDataset", voucherData));

            byte[] pdfBytes = report.Render("PDF");
            return pdfBytes;
        }
    }
}