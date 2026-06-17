SELECT 
    c.ChallanNo AS VoucherNo,
    s.RegistrationNo AS StudentId,
    s.StudentName,
    c.Semester AS ClassName,       -- Mapping Semester to ClassName
    c.ChallanMonth AS TermOrMonth,
    FORMAT(c.IssueDate, 'dd-MMM-yyyy') AS IssueDate,
    FORMAT(c.DueDate, 'dd-MMM-yyyy') AS DueDate,
    
    -- Fee Item Details
    fh.HeadName AS FeeHeadName,
    cd.NetAmount AS Amount,       -- Using NetAmount to account for any line-item discounts
    
    -- Summary Info
    c.NetPayable AS TotalAmount,
    c.Status
FROM dbo.Challans c
INNER JOIN dbo.Students s ON c.StudentID = s.StudentID
INNER JOIN dbo.ChallanDetails cd ON c.Uid = cd.ChallanID
INNER JOIN dbo.ref_FeeHeads fh ON cd.FeeHeadID = fh.Uid
WHERE c.ChallanNo = @ChallanNo AND c.IsActive = 1