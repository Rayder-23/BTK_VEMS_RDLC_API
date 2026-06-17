namespace VEMS.PrintEngine.Services
{
    public interface IFeeChallanService
    {
        Task<byte[]> GenerateChallanPdfAsync(string challanNo);
    }
}