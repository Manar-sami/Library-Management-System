
public class Magazine : LibraryItem
{
    public int IssueNumber { get; set; }

    public Magazine(int id, string title, bool isAvailable, bool isActive,
                    int issueNumber)
        : base(id, title, isAvailable, isActive)
    {
        IssueNumber = issueNumber;
    }

    public override decimal CalculateLateFee()
{
    return 2m;
}

public override int GetLoanPeriod()
{
    return 7;
}

public override string ToString()
    {
        return $"ID:{Id} ---- Title:{Title} ---- IsAvailable:{IsAvailable} ----- IsActive:{IsActive} ---- IssueNumber:{IssueNumber}";
    }

}
