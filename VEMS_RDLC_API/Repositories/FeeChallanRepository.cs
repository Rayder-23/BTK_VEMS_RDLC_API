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

        /// <summary>
        /// Fetches the multi-row flat dataset required to populate the fee voucher's tabular layout.
        /// </summary>
        /// <param name="challanNo">The unique alphanumeric challan identification sequence.</param>
        public async Task<List<FeeChallanReportModel>> GetChallanPrintDataAsync(string challanNo)
        {
            // Raw SQL relational data retrieval combining your VEMS ledger tables
            // Note: When your friend converts this to a Stored Procedure, you will simply rewrite this string as:
            // "EXEC GetFeeChallanPrintData {0}"
            // Tailored query precisely aligning with your SQL schemas:
            // c.Uid -> cd.ChallanID and cd.FeeHeadID -> fh.Uid
            string query = @"
                SELECT 
                    c.ChallanNo,
                    'HBL Bank' AS BankName,                                       
                    '0123-456789-01' AS AccountNo,                                
                    CONVERT(VARCHAR, c.IssueDate, 106) AS IssueDate,
                    CONVERT(VARCHAR, c.DueDate, 106) AS DueDate,
                    CAST(s.StudentID AS VARCHAR(50)) AS StudentID,
                    s.StudentName,
                    '' AS FatherName,                                             
                    c.Semester AS ClassSection,                                   
                    c.Semester,
                    ISNULL(c.ChallanMonth, '') + ' ' + ISNULL(c.ChallanYear, '') AS [Session],
                    fh.HeadName AS FeeHeadName,
                    cd.Amount,                                                    
                    c.TotalAmount,                                                
                    c.LateFineAmount AS LateFeeFine,
                    c.NetPayable AS GrossAmount,
                    '' AS AmountInWords                                          
                FROM dbo.Challans c
                INNER JOIN dbo.Students s ON c.StudentID = s.StudentID
                INNER JOIN dbo.ChallanDetails cd ON c.Uid = cd.ChallanID
                INNER JOIN dbo.ref_FeeHeads fh ON cd.FeeHeadID = fh.Uid
                WHERE c.ChallanNo = {0}";

            // Executing the query asynchronously through Entity Framework Core
            return await _context.Database
                .SqlQueryRaw<FeeChallanReportModel>(query, challanNo)
                .ToListAsync();
        }
    }
}