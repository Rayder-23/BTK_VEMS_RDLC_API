using VEMS.PrintEngine.Models;

namespace VEMS.PrintEngine.Repositories
{
    public interface IFeeChallanRepository
    {
        Task<List<FeeChallanReportModel>> GetChallanPrintDataAsync(string challanNo);
    }
}