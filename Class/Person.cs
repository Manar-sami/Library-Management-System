public class Person
{
    public int Id {get;set;}
    public string Name{get;set;}
    public string Password{get;set;}
    public string PhoneNumber {get;set;}

    public string Address{get;set;}

     public Person(){}
    public Person(int id,string name,string password,string phoneNumber,string address)
    {
        Id=id;
        Name=name;
        Password=password;
        PhoneNumber=phoneNumber;
        Address=address;
    }  

     

    //  داله التحقق من id و password

    public bool CheckPasswordandId(int id,string password)
    {
        if(Id==id && Password == password)
        {
            return true;
        }
        return false;
    }

    

}
