public class Member : Person
{
    public int MembershipId { get; set; }
    public int MaxLoanLimit { get; set; }
    public bool IsActive { get; set; } = true;
    public Member(){}

    public Member(int id,string name,string password,string phoneNumber,string address,int membershipId,int maxLoanLimit,bool isactive) : base(id, name, password, phoneNumber, address)
    {
        MembershipId = membershipId;
        MaxLoanLimit = maxLoanLimit;
        IsActive=isactive;
    }


  public override string ToString()
    {
        return $"Id:{Id} || Name:{Name} || PhoneNumber:{PhoneNumber} || Address:{Address} || MembershipId:{MembershipId} || MaxLoanLimit:{MaxLoanLimit} || IsActive:{IsActive}";
    }
}