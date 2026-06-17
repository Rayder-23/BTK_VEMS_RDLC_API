namespace VEMS.PrintEngine.Models
{
    public class FeeVoucherReportModel
    {
        // Header Info initialized to empty strings to suppress CS8618 warning
        public string VoucherNo { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string TermOrMonth { get; set; } = string.Empty;
        public string IssueDate { get; set; } = string.Empty;
        public string DueDate { get; set; } = string.Empty;

        // Line Item Detail
        public string FeeHeadName { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        // Total Summaries
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        
        // Dynamic property generated at runtime
        public string AmountInWords => ConvertAmountToWords(TotalAmount);

        private static string ConvertAmountToWords(decimal amount)
        {
            // Simple fallback helper; you can expand this with a proper library or custom logic
            try
            {
                long number = Convert.ToInt64(Math.Floor(amount));
                if (number == 0) return "Zero Rupees Only";
                return NumberToWords(number) + " Rupees Only";
            }
            catch { return ""; }
        }

        private static string NumberToWords(long number)
        {
            if (number < 0) return "Minus " + NumberToWords(Math.Abs(number));
            
            var words = "";
            // Add your preferred number-to-words engine logic here
            // For brevity, a placeholder that you can swap with standard utility code
            if ((number / 1000) > 0) { words += NumberToWords(number / 1000) + " Thousand "; number %= 1000; }
            if ((number / 100) > 0) { words += NumberToWords(number / 100) + " Hundred "; number %= 100; }
            
            if (number > 0)
            {
                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += "-" + unitsMap[number % 10];
                }
            }
            return words.Trim();
        }
    }
}