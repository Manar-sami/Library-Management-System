public abstract class LibraryItem
{
   public int Id {get;set;}
   public string Title{get;set;}
   public bool IsAvailable{get;set;}
   public bool IsActive{get;set;}

   public LibraryItem (int id,string title,bool isavailable,bool isactive)
    {
        Id=id;
        Title=title;
        IsAvailable=isavailable;
        IsActive=isactive;
    }


    public abstract decimal CalculateLateFee() ;
     public abstract int GetLoanPeriod() ;

    public bool CheckedId(int id )
    {
        if (Id == id)
        {
             return true;
        }
        return false;

    }
}