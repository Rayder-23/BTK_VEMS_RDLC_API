namespace VEMS.PrintEngine.Models
{
    public class FeeChallanReportModel
    {
        // ========== Students Table Fields ==========
        public int StudentID { get; set; }
        public string? RegistrationNo { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public bool Student_IsActive { get; set; }
        public DateTime Student_CreatedOn { get; set; }

        // ========== Challans Table Fields ==========
        public int Challan_Uid { get; set; }
        public string ChallanNo { get; set; } = string.Empty;
        public int? Challan_StudentID { get; set; }
        public int? StructureID { get; set; }
        public string Semester { get; set; } = string.Empty;
        public short AcademicYear { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Challan_DiscountAmount { get; set; }
        public decimal LateFineAmount { get; set; }
        public decimal NetPayable { get; set; }
        public decimal AmountPaid { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Remarks { get; set; }
        public bool Challan_IsActive { get; set; }
        public int Challan_CreatedBy { get; set; }
        public DateTime Challan_CreatedAt { get; set; }
        public int? Challan_UpdatedBy { get; set; }
        public DateTime? Challan_UpdatedAt { get; set; }
        public int? ApplicationUid { get; set; }
        public string? ChallanMonth { get; set; }
        public string? ChallanYear { get; set; }

        // ========== Aggregated Totals ==========
        public int TotalDetailCount { get; set; }
        public decimal TotalDetailAmount { get; set; }
        public decimal TotalDetailDiscount { get; set; }
        public decimal TotalDetailLateFine { get; set; }
        public decimal TotalDetailNetAmount { get; set; }

        // ========== Detail 1 (FeeHeadID = 1) ==========
        public int? Detail1_Uid { get; set; }
        public short? Detail1_FeeHeadID { get; set; }
        public decimal Detail1_Amount { get; set; }
        public decimal Detail1_DiscountAmount { get; set; }
        public decimal Detail1_LateFine { get; set; }
        public decimal Detail1_NetAmount { get; set; }
        public int? Detail1_CreatedBy { get; set; }
        public DateTime? Detail1_CreatedAt { get; set; }

        // ========== Detail 2 (FeeHeadID = 2) ==========
        public int? Detail2_Uid { get; set; }
        public short? Detail2_FeeHeadID { get; set; }
        public decimal Detail2_Amount { get; set; }
        public decimal Detail2_DiscountAmount { get; set; }
        public decimal Detail2_LateFine { get; set; }
        public decimal Detail2_NetAmount { get; set; }
        public int? Detail2_CreatedBy { get; set; }
        public DateTime? Detail2_CreatedAt { get; set; }

        // ========== Detail 3 (FeeHeadID = 3) ==========
        public int? Detail3_Uid { get; set; }
        public short? Detail3_FeeHeadID { get; set; }
        public decimal Detail3_Amount { get; set; }
        public decimal Detail3_DiscountAmount { get; set; }
        public decimal Detail3_LateFine { get; set; }
        public decimal Detail3_NetAmount { get; set; }
        public int? Detail3_CreatedBy { get; set; }
        public DateTime? Detail3_CreatedAt { get; set; }

        // ========== Detail 4 (FeeHeadID = 4) ==========
        public int? Detail4_Uid { get; set; }
        public short? Detail4_FeeHeadID { get; set; }
        public decimal Detail4_Amount { get; set; }
        public decimal Detail4_DiscountAmount { get; set; }
        public decimal Detail4_LateFine { get; set; }
        public decimal Detail4_NetAmount { get; set; }
        public int? Detail4_CreatedBy { get; set; }
        public DateTime? Detail4_CreatedAt { get; set; }

        // ========== Detail 5 (FeeHeadID = 5) ==========
        public int? Detail5_Uid { get; set; }
        public short? Detail5_FeeHeadID { get; set; }
        public decimal Detail5_Amount { get; set; }
        public decimal Detail5_DiscountAmount { get; set; }
        public decimal Detail5_LateFine { get; set; }
        public decimal Detail5_NetAmount { get; set; }
        public int? Detail5_CreatedBy { get; set; }
        public DateTime? Detail5_CreatedAt { get; set; }

        // ========== Detail 6 (FeeHeadID = 6) ==========
        public int? Detail6_Uid { get; set; }
        public short? Detail6_FeeHeadID { get; set; }
        public decimal Detail6_Amount { get; set; }
        public decimal Detail6_DiscountAmount { get; set; }
        public decimal Detail6_LateFine { get; set; }
        public decimal Detail6_NetAmount { get; set; }
        public int? Detail6_CreatedBy { get; set; }
        public DateTime? Detail6_CreatedAt { get; set; }

        // ========== Detail 7 (FeeHeadID = 7) ==========
        public int? Detail7_Uid { get; set; }
        public short? Detail7_FeeHeadID { get; set; }
        public decimal Detail7_Amount { get; set; }
        public decimal Detail7_DiscountAmount { get; set; }
        public decimal Detail7_LateFine { get; set; }
        public decimal Detail7_NetAmount { get; set; }
        public int? Detail7_CreatedBy { get; set; }
        public DateTime? Detail7_CreatedAt { get; set; }
    }
}