using VEMS.PrintEngine.Models;

namespace VEMS.PrintEngine.Services
{
    public interface IFeeChallanService
    {
        Task<byte[]> GenerateChallanPdfAsync(string challanNo);
        
        // ◄ NEW: Method to return raw data for testing
        Task<List<FeeChallanReportModel>> GetChallanDataAsync(string challanNo);
    }
}