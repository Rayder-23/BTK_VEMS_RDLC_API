USE [VEMS]
GO

/****** Object:  StoredProcedure [dbo].[GetChallanData]    Script Date: 18/06/2026 12:58:59 pm ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetChallanData]
    @ChallanNo NVARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    WITH ChallanDetailsPivot AS
    (
        SELECT 
            cd.ChallanID,
            
            -- ========== FeeHeadID = 1 ==========
            MAX(CASE WHEN cd.FeeHeadID = 1 THEN cd.Uid END) AS Detail1_Uid,
            MAX(CASE WHEN cd.FeeHeadID = 1 THEN cd.FeeHeadID END) AS Detail1_FeeHeadID,
            MAX(CASE WHEN cd.FeeHeadID = 1 THEN cd.Amount END) AS Detail1_Amount,
            MAX(CASE WHEN cd.FeeHeadID = 1 THEN cd.DiscountAmount END) AS Detail1_DiscountAmount,
            MAX(CASE WHEN cd.FeeHeadID = 1 THEN cd.LateFine END) AS Detail1_LateFine,
            MAX(CASE WHEN cd.FeeHeadID = 1 THEN cd.NetAmount END) AS Detail1_NetAmount,
            MAX(CASE WHEN cd.FeeHeadID = 1 THEN cd.CreatedBy END) AS Detail1_CreatedBy,
            MAX(CASE WHEN cd.FeeHeadID = 1 THEN cd.CreatedAt END) AS Detail1_CreatedAt,
            
            -- ========== FeeHeadID = 2 ==========
            MAX(CASE WHEN cd.FeeHeadID = 2 THEN cd.Uid END) AS Detail2_Uid,
            MAX(CASE WHEN cd.FeeHeadID = 2 THEN cd.FeeHeadID END) AS Detail2_FeeHeadID,
            MAX(CASE WHEN cd.FeeHeadID = 2 THEN cd.Amount END) AS Detail2_Amount,
            MAX(CASE WHEN cd.FeeHeadID = 2 THEN cd.DiscountAmount END) AS Detail2_DiscountAmount,
            MAX(CASE WHEN cd.FeeHeadID = 2 THEN cd.LateFine END) AS Detail2_LateFine,
            MAX(CASE WHEN cd.FeeHeadID = 2 THEN cd.NetAmount END) AS Detail2_NetAmount,
            MAX(CASE WHEN cd.FeeHeadID = 2 THEN cd.CreatedBy END) AS Detail2_CreatedBy,
            MAX(CASE WHEN cd.FeeHeadID = 2 THEN cd.CreatedAt END) AS Detail2_CreatedAt,
            
            -- ========== FeeHeadID = 3 ==========
            MAX(CASE WHEN cd.FeeHeadID = 3 THEN cd.Uid END) AS Detail3_Uid,
            MAX(CASE WHEN cd.FeeHeadID = 3 THEN cd.FeeHeadID END) AS Detail3_FeeHeadID,
            MAX(CASE WHEN cd.FeeHeadID = 3 THEN cd.Amount END) AS Detail3_Amount,
            MAX(CASE WHEN cd.FeeHeadID = 3 THEN cd.DiscountAmount END) AS Detail3_DiscountAmount,
            MAX(CASE WHEN cd.FeeHeadID = 3 THEN cd.LateFine END) AS Detail3_LateFine,
            MAX(CASE WHEN cd.FeeHeadID = 3 THEN cd.NetAmount END) AS Detail3_NetAmount,
            MAX(CASE WHEN cd.FeeHeadID = 3 THEN cd.CreatedBy END) AS Detail3_CreatedBy,
            MAX(CASE WHEN cd.FeeHeadID = 3 THEN cd.CreatedAt END) AS Detail3_CreatedAt,
            
            -- ========== FeeHeadID = 4 ==========
            MAX(CASE WHEN cd.FeeHeadID = 4 THEN cd.Uid END) AS Detail4_Uid,
            MAX(CASE WHEN cd.FeeHeadID = 4 THEN cd.FeeHeadID END) AS Detail4_FeeHeadID,
            MAX(CASE WHEN cd.FeeHeadID = 4 THEN cd.Amount END) AS Detail4_Amount,
            MAX(CASE WHEN cd.FeeHeadID = 4 THEN cd.DiscountAmount END) AS Detail4_DiscountAmount,
            MAX(CASE WHEN cd.FeeHeadID = 4 THEN cd.LateFine END) AS Detail4_LateFine,
            MAX(CASE WHEN cd.FeeHeadID = 4 THEN cd.NetAmount END) AS Detail4_NetAmount,
            MAX(CASE WHEN cd.FeeHeadID = 4 THEN cd.CreatedBy END) AS Detail4_CreatedBy,
            MAX(CASE WHEN cd.FeeHeadID = 4 THEN cd.CreatedAt END) AS Detail4_CreatedAt,
            
            -- ========== FeeHeadID = 5 ==========
            MAX(CASE WHEN cd.FeeHeadID = 5 THEN cd.Uid END) AS Detail5_Uid,
            MAX(CASE WHEN cd.FeeHeadID = 5 THEN cd.FeeHeadID END) AS Detail5_FeeHeadID,
            MAX(CASE WHEN cd.FeeHeadID = 5 THEN cd.Amount END) AS Detail5_Amount,
            MAX(CASE WHEN cd.FeeHeadID = 5 THEN cd.DiscountAmount END) AS Detail5_DiscountAmount,
            MAX(CASE WHEN cd.FeeHeadID = 5 THEN cd.LateFine END) AS Detail5_LateFine,
            MAX(CASE WHEN cd.FeeHeadID = 5 THEN cd.NetAmount END) AS Detail5_NetAmount,
            MAX(CASE WHEN cd.FeeHeadID = 5 THEN cd.CreatedBy END) AS Detail5_CreatedBy,
            MAX(CASE WHEN cd.FeeHeadID = 5 THEN cd.CreatedAt END) AS Detail5_CreatedAt,
            
            -- ========== FeeHeadID = 6 ==========
            MAX(CASE WHEN cd.FeeHeadID = 6 THEN cd.Uid END) AS Detail6_Uid,
            MAX(CASE WHEN cd.FeeHeadID = 6 THEN cd.FeeHeadID END) AS Detail6_FeeHeadID,
            MAX(CASE WHEN cd.FeeHeadID = 6 THEN cd.Amount END) AS Detail6_Amount,
            MAX(CASE WHEN cd.FeeHeadID = 6 THEN cd.DiscountAmount END) AS Detail6_DiscountAmount,
            MAX(CASE WHEN cd.FeeHeadID = 6 THEN cd.LateFine END) AS Detail6_LateFine,
            MAX(CASE WHEN cd.FeeHeadID = 6 THEN cd.NetAmount END) AS Detail6_NetAmount,
            MAX(CASE WHEN cd.FeeHeadID = 6 THEN cd.CreatedBy END) AS Detail6_CreatedBy,
            MAX(CASE WHEN cd.FeeHeadID = 6 THEN cd.CreatedAt END) AS Detail6_CreatedAt,
            
            -- ========== FeeHeadID = 7 ==========
            MAX(CASE WHEN cd.FeeHeadID = 7 THEN cd.Uid END) AS Detail7_Uid,
            MAX(CASE WHEN cd.FeeHeadID = 7 THEN cd.FeeHeadID END) AS Detail7_FeeHeadID,
            MAX(CASE WHEN cd.FeeHeadID = 7 THEN cd.Amount END) AS Detail7_Amount,
            MAX(CASE WHEN cd.FeeHeadID = 7 THEN cd.DiscountAmount END) AS Detail7_DiscountAmount,
            MAX(CASE WHEN cd.FeeHeadID = 7 THEN cd.LateFine END) AS Detail7_LateFine,
            MAX(CASE WHEN cd.FeeHeadID = 7 THEN cd.NetAmount END) AS Detail7_NetAmount,
            MAX(CASE WHEN cd.FeeHeadID = 7 THEN cd.CreatedBy END) AS Detail7_CreatedBy,
            MAX(CASE WHEN cd.FeeHeadID = 7 THEN cd.CreatedAt END) AS Detail7_CreatedAt,

            -- ========== Aggregated Totals ==========
            COUNT(*) AS TotalDetailCount,
            SUM(cd.Amount) AS TotalDetailAmount,
            SUM(cd.DiscountAmount) AS TotalDetailDiscount,
            SUM(cd.LateFine) AS TotalDetailLateFine,
            SUM(cd.NetAmount) AS TotalDetailNetAmount

        FROM 
            ChallanDetails cd
        GROUP BY 
            cd.ChallanID
    )

    SELECT 
        -- ========== Students Table Fields ==========
        s.StudentID,
        s.RegistrationNo,
        s.StudentName,
        s.MobileNo,
        s.Email,
        s.IsActive AS Student_IsActive,
        s.CreatedOn AS Student_CreatedOn,

        -- ========== Challans Table Fields ==========
        c.Uid AS Challan_Uid,
        c.ChallanNo,
        c.StudentID AS Challan_StudentID,
        c.StructureID,
        c.Semester,
        c.AcademicYear,
        c.IssueDate,
        c.DueDate,
        c.TotalAmount,
        c.DiscountAmount AS Challan_DiscountAmount,
        c.LateFineAmount,
        c.NetPayable,
        c.AmountPaid,
        c.Status,
        c.Remarks,
        c.IsActive AS Challan_IsActive,
        c.CreatedBy AS Challan_CreatedBy,
        c.CreatedAt AS Challan_CreatedAt,
        c.UpdatedBy AS Challan_UpdatedBy,
        c.UpdatedAt AS Challan_UpdatedAt,
        c.ApplicationUid,
        c.ChallanMonth,
        c.ChallanYear,

        -- ========== Aggregated Totals ==========
        ISNULL(cdp.TotalDetailCount, 0) AS TotalDetailCount,
        ISNULL(cdp.TotalDetailAmount, 0) AS TotalDetailAmount,
        ISNULL(cdp.TotalDetailDiscount, 0) AS TotalDetailDiscount,
        ISNULL(cdp.TotalDetailLateFine, 0) AS TotalDetailLateFine,
        ISNULL(cdp.TotalDetailNetAmount, 0) AS TotalDetailNetAmount,

        -- ========== Detail 1 (FeeHeadID = 1) ==========
        cdp.Detail1_Uid,
        cdp.Detail1_FeeHeadID,
        ISNULL(cdp.Detail1_Amount, 0) AS Detail1_Amount,
        ISNULL(cdp.Detail1_DiscountAmount, 0) AS Detail1_DiscountAmount,
        ISNULL(cdp.Detail1_LateFine, 0) AS Detail1_LateFine,
        ISNULL(cdp.Detail1_NetAmount, 0) AS Detail1_NetAmount,
        cdp.Detail1_CreatedBy,
        cdp.Detail1_CreatedAt,

        -- ========== Detail 2 (FeeHeadID = 2) ==========
        cdp.Detail2_Uid,
        cdp.Detail2_FeeHeadID,
        ISNULL(cdp.Detail2_Amount, 0) AS Detail2_Amount,
        ISNULL(cdp.Detail2_DiscountAmount, 0) AS Detail2_DiscountAmount,
        ISNULL(cdp.Detail2_LateFine, 0) AS Detail2_LateFine,
        ISNULL(cdp.Detail2_NetAmount, 0) AS Detail2_NetAmount,
        cdp.Detail2_CreatedBy,
        cdp.Detail2_CreatedAt,

        -- ========== Detail 3 (FeeHeadID = 3) ==========
        cdp.Detail3_Uid,
        cdp.Detail3_FeeHeadID,
        ISNULL(cdp.Detail3_Amount, 0) AS Detail3_Amount,
        ISNULL(cdp.Detail3_DiscountAmount, 0) AS Detail3_DiscountAmount,
        ISNULL(cdp.Detail3_LateFine, 0) AS Detail3_LateFine,
        ISNULL(cdp.Detail3_NetAmount, 0) AS Detail3_NetAmount,
        cdp.Detail3_CreatedBy,
        cdp.Detail3_CreatedAt,

        -- ========== Detail 4 (FeeHeadID = 4) ==========
        cdp.Detail4_Uid,
        cdp.Detail4_FeeHeadID,
        ISNULL(cdp.Detail4_Amount, 0) AS Detail4_Amount,
        ISNULL(cdp.Detail4_DiscountAmount, 0) AS Detail4_DiscountAmount,
        ISNULL(cdp.Detail4_LateFine, 0) AS Detail4_LateFine,
        ISNULL(cdp.Detail4_NetAmount, 0) AS Detail4_NetAmount,
        cdp.Detail4_CreatedBy,
        cdp.Detail4_CreatedAt,

        -- ========== Detail 5 (FeeHeadID = 5) ==========
        cdp.Detail5_Uid,
        cdp.Detail5_FeeHeadID,
        ISNULL(cdp.Detail5_Amount, 0) AS Detail5_Amount,
        ISNULL(cdp.Detail5_DiscountAmount, 0) AS Detail5_DiscountAmount,
        ISNULL(cdp.Detail5_LateFine, 0) AS Detail5_LateFine,
        ISNULL(cdp.Detail5_NetAmount, 0) AS Detail5_NetAmount,
        cdp.Detail5_CreatedBy,
        cdp.Detail5_CreatedAt,

        -- ========== Detail 6 (FeeHeadID = 6) ==========
        cdp.Detail6_Uid,
        cdp.Detail6_FeeHeadID,
        ISNULL(cdp.Detail6_Amount, 0) AS Detail6_Amount,
        ISNULL(cdp.Detail6_DiscountAmount, 0) AS Detail6_DiscountAmount,
        ISNULL(cdp.Detail6_LateFine, 0) AS Detail6_LateFine,
        ISNULL(cdp.Detail6_NetAmount, 0) AS Detail6_NetAmount,
        cdp.Detail6_CreatedBy,
        cdp.Detail6_CreatedAt,

        -- ========== Detail 7 (FeeHeadID = 7) ==========
        cdp.Detail7_Uid,
        cdp.Detail7_FeeHeadID,
        ISNULL(cdp.Detail7_Amount, 0) AS Detail7_Amount,
        ISNULL(cdp.Detail7_DiscountAmount, 0) AS Detail7_DiscountAmount,
        ISNULL(cdp.Detail7_LateFine, 0) AS Detail7_LateFine,
        ISNULL(cdp.Detail7_NetAmount, 0) AS Detail7_NetAmount,
        cdp.Detail7_CreatedBy,
        cdp.Detail7_CreatedAt

    FROM 
        Students s
        INNER JOIN Challans c ON s.StudentID = c.StudentID
        LEFT JOIN ChallanDetailsPivot cdp ON c.Uid = cdp.ChallanID
    WHERE 
        (@ChallanNo IS NULL OR c.ChallanNo = @ChallanNo)
    ORDER BY 
        s.RegistrationNo, 
        c.ChallanNo;
END;
GO