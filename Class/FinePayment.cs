public class FinePayment
{
    public int PaymentId { get; set; }
    public int MemberId { get; set; }
    public int ItemId { get; set; }
    public decimal Amount { get; set; }
    public DateOnly PaymentDate { get; set; }

    public FinePayment(int paymentId, int memberId, int itemId,
                       decimal amount, DateOnly paymentDate)
    {
        PaymentId = paymentId;
        MemberId = memberId;
        ItemId = itemId;
        Amount = amount;
        PaymentDate = paymentDate;
    }
}
