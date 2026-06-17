namespace VEMS.PrintEngine.Models
{
    public class FeeChallanReportModel
    {
        public string ChallanNo { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public string IssueDate { get; set; } = string.Empty;
        public string DueDate { get; set; } = string.Empty;
        public string StudentID { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public string ClassSection { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public string Session { get; set; } = string.Empty;
        public string FeeHeadName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal LateFeeFine { get; set; }
        public decimal GrossAmount { get; set; }
        public string AmountInWords { get; set; } = string.Empty;
    }
}