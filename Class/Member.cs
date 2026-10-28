public class Member : Person
{
    public int MembershipId { get; set; }
    public int MaxLoanLimit { get; set; }
    public Member(){}

    public Member(int id,string name,string password,string phoneNumber,string address,int membershipId,int maxLoanLimit) : base(id, name, password, phoneNumber, address)
    {
        MembershipId = membershipId;
        MaxLoanLimit = maxLoanLimit;
    }


  public override string ToString()
    {
        return $"Id:{Id} || Name:{Name} || PhoneNumber:{PhoneNumber} || Address:{Address} || MembershipId:{MembershipId} || MaxLoanLimit:{MaxLoanLimit}";
    }
}