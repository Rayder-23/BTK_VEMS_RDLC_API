using Microsoft.EntityFrameworkCore;
using VEMS.PrintEngine.Data;
using VEMS.PrintEngine.Models;

namespace VEMS.PrintEngine.Repositories
{
    public class FeeChallanRepository : IFeeChallanRepository
    {
        private readonly VemsDbContext _context;

        public FeeChallanRepository(VemsDbContext context)
        {
            _context = context;
        }

        public async Task<List<FeeChallanReportModel>> GetChallanPrintDataAsync(string challanNo)
        {
            // Execute the stored procedure safely using parameterized queries
            string query = "EXEC dbo.GetChallanData @ChallanNo = {0}";

            return await _context.Database
                .SqlQueryRaw<FeeChallanReportModel>(query, challanNo)
                .ToListAsync();
        }
    }
}