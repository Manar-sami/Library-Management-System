public class Loan
{
    public int MemberId { get; set; }
    public int ItemId { get; set; }
    public DateOnly LoanDate { get; set; }
    public DateOnly ExpectedReturnDate { get; set; }
    public DateOnly? ActualReturnDate { get; set; }
    public decimal FineAmount { get; set; }
    public decimal FinePaidAmount { get; set; }

    public Loan(int memberId, int itemId, DateOnly loanDate, DateOnly expectedReturnDate)
    {
        MemberId = memberId;
        ItemId = itemId;
        LoanDate = loanDate;
        ExpectedReturnDate = expectedReturnDate;
        ActualReturnDate = null;
        FineAmount = 0;
        FinePaidAmount = 0;
    }
}
