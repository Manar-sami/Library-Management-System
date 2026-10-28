public class Book:LibraryItem
{
   public string Author { get; set; }
   public int Pages { get; set; }
  
   
   public Book(int id, string title, bool isAvailable, bool isActive,string author, int pages): base(id, title, isAvailable, isActive)
   {
      Author = author;
      Pages = pages;
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
        return $"ID:{Id} ---- Title:{Title} ---- IsAvailable:{IsAvailable} ----- IsActive:{IsActive} ---- Author:{Author} ---- Pages:{Pages}";
    }

}