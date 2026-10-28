using Microsoft.VisualBasic;

namespace Library;

public class LibraryManagement
{
    List<Person> person;
    List<LibraryItem> items;
    List<Loan> loans = new List<Loan>();
private int nextId = 3;
    public LibraryManagement()
    {
        person = new List<Person>()
    {

        new Member()
        {
            Id = 1,
            Name = "Manar",
            Password = "12345",
            PhoneNumber = "0567070911",
            Address = "Nablus",
            MembershipId = 101,
            MaxLoanLimit=5
        },

        new Librarian()
        {
            Id = 2,
            Name = "Ahmad",
            Password = "123@",
            PhoneNumber = "0599999999",
            Address = "Nablus",
            Position = "Librarian"
        }
    };


        items = new List<LibraryItem>()
        {
            new Book(1, "C# Basics", true, true, "John Smith", 250),

    new Book(2, "Learn OOP", false, true, "Ahmed Ali", 300),

    new Magazine(3, "Technology Today", true, true, 12),

    new Magazine(4, "Science World", true, false, 5),

    new ResearchPaper(5, "Artificial Intelligence", true, true,
        "Sara Ahmad", "Computer Science"),

    new ResearchPaper(6, "Cyber Security", false, true,
        "Omar Khaled", "Information Security")
        };
    }


    // داله تشغيل البرنامج 
    public void Run()
    {
        int choice;

        do
        {
            Console.WriteLine("===== Library Management System =====");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register New Member");
            Console.WriteLine("3. Browse Library");
            Console.WriteLine("4. Search for Items");
            Console.WriteLine("5. Exit");

            Console.WriteLine("Please choose an option (1-5): ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: Login(); break;
                case 2: RegisterNewMember(); break;
                case 3: BrowseLibrary(); break;
                case 4: SearchForItems(); break;
                case 5: Console.WriteLine("Bye"); break;
                default: Console.WriteLine("Invalid choice!"); break;
            }


        } while (choice != 5);
    }



    //   داله التسجيل 
    private void Login()
    {


        Console.WriteLine("Enter you Id :");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter your password");
        string password = Console.ReadLine();

        foreach (Person p in person)
        {

            if (p.CheckPasswordandId(id, password))
            {
                Console.WriteLine($"hello {p.Name}");
                if (p is Librarian)
                {
                    LibrarianMenu();
                }
                else if (p is Member)
                {
                    MemberMenu();
                }

                break;

            }


            Console.WriteLine("Invalid ID or password!");




        }



    }


    private void BrowseLibrary()
    {
        Console.WriteLine("BrowseLibrary");
    }

    //  عرض قائمة خاصة بالموظف
    private void LibrarianMenu()
    {
        int choice;
        do
        {

            Console.WriteLine("===== Librarian Menu =====");
            Console.WriteLine("1. Add New Item");
            Console.WriteLine("2. Display All Items");
            Console.WriteLine("3. Search by Title or Item ID");
            Console.WriteLine("4. Display Available Items");
            Console.WriteLine("5. View Item Details");
            Console.WriteLine("6. Edit Item");
            Console.WriteLine("7. Deactivate Item");
            Console.WriteLine("8.Logout");


            Console.WriteLine("Please choose an option (1-8): ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: AddNewItem(); break;
                case 2: ShowAllItems(); break;
                case 3: SearchForItems(); break;
                case 4: DisplayAvailableItems(); break;
                case 5:ViewItemDetails();break;
                case 6:EditItem();break;
                case 7:DeactivateItem();break;
                case 8: Run(); break;
                default:Console.WriteLine("wrong choice");break;
            }

        } while (choice != 8);

    }
      
    //    عرض قائمة خاصة بالاعضاء
    public void MemberMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("--- Members Management ---");
            Console.WriteLine("1. Register New Member");
            Console.WriteLine("2. Display All Members");
            Console.WriteLine("3. Search Member by Membership ID");
            Console.WriteLine("4. View Member Details and Loan History");
            Console.WriteLine("5. Set Maximum Loan Limit");
            Console.WriteLine("6. Deactivate Member");
            Console.WriteLine("7.Logout");

            Console.WriteLine("Please choose an option (1-7): ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:RegisterNewMember(); break;
                 case 2:ShowAllMembers();break;
                 case 3:SearchMemberByMembershipId();break;
                 case 4: ViewMemberDetailsAndLoanHistory();break;
                 case 5:SetMaximumLoanLimit();break;
                case 7: Run(); break;
                default:Console.WriteLine("wrong choice");break;
            }

        } while (choice !=7);
    }


    //    داله لاضافة مادة 
    private void AddNewItem()
    {
        Console.WriteLine("Enter the type of subject you want to add [Book | Magazin | ResearchPaper]");
        string Type = Console.ReadLine();
        Console.WriteLine("Enter the subject ID.");
        int id = int.Parse(Console.ReadLine());
        foreach (LibraryItem item in items)
        {
            if (id == item.Id)
            {
                Console.WriteLine("This ID is already taken. Please choose a different number.");
                return;
            }
        }
        Console.WriteLine("Enter the subject title.");
        string title = Console.ReadLine();

        Console.WriteLine("Is the item available? (true/false):");
        bool isAvailable = bool.Parse(Console.ReadLine());

        Console.WriteLine("Is the item active? (true/false):");
        bool isActive = bool.Parse(Console.ReadLine());


        switch (Type)
        {
            case "Book":

                Console.WriteLine("Enter the author:");
                string author = Console.ReadLine();

                Console.WriteLine("Enter the number of pages:");
                int pages = int.Parse(Console.ReadLine());

                Book book = new Book(id, title, isAvailable, isActive, author, pages);

                items.Add(book);

                Console.WriteLine("Book added successfully!"); break;

            case "Magazin":
                Console.WriteLine("Enter the version number.");
                int version = int.Parse(Console.ReadLine());
                Magazine magazine = new Magazine(id, title, isAvailable, isActive, version);
                items.Add(magazine);
                Console.WriteLine("Magazin added successfully!"); break;

            case "ResearchPaper":

                Console.WriteLine("Enter the researcher's name.");
                string Researcher = Console.ReadLine();
                Console.WriteLine("Enter the research field.");
                string ResearchField = Console.ReadLine();
                ResearchPaper researchPaper = new ResearchPaper(id, title, isAvailable, isActive, Researcher, ResearchField);
                items.Add(researchPaper);
                Console.WriteLine("ResearchPaper added successfully!"); break;

            default: Console.WriteLine("Invalid option. Please select a valid option."); break;
        }


    }


    // داله بتعرض جميع المواد 

    public void ShowAllItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("No items available.");
        }
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }


    //  دالخ للبحث عن مادة 
    private void SearchForItems()
    {
        Console.WriteLine("1. Search by Title");
        Console.WriteLine("2. Search by Item ID");
        Console.WriteLine("Choose search method:");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Please enter the title.");
                string Title = Console.ReadLine();
                bool found = false;
                foreach (var item in items)
                {


                    if (Title == item.Title)
                    {
                        found = true;
                        Console.WriteLine("This item already exists.");
                        Console.WriteLine("---------");
                        Console.WriteLine($"Id:{item.Id}");
                        Console.WriteLine("---------");
                        Console.WriteLine($"Title:{item.Title}");
                        Console.WriteLine("---------");
                        Console.WriteLine($"IsActive:{item.IsActive}");
                        Console.WriteLine("---------");
                        Console.WriteLine($"IsAvailable:{item.IsAvailable}");

                        break;
                    }




                }
                if (found == false)
                {
                    Console.WriteLine("This item does not exist.");
                }

                break;

            case 2:

                Console.WriteLine("Please enter the Id.");
                int Id = int.Parse(Console.ReadLine());
                bool foundd = false;
                foreach (var item in items)
                {


                    if (Id == item.Id)
                    {
                        foundd = true;
                        Console.WriteLine("This item already exists.");
                        Console.WriteLine("---------");
                        Console.WriteLine($"Id:{item.Id}");
                        Console.WriteLine("---------");
                        Console.WriteLine($"Title:{item.Title}");
                        Console.WriteLine("---------");
                        Console.WriteLine($"IsActive:{item.IsActive}");
                        Console.WriteLine("---------");
                        Console.WriteLine($"IsAvailable:{item.IsAvailable}");
                        return;
                    }




                }
                if (foundd == false)
                {
                    Console.WriteLine("This item does not exist.");
                }

                break;

            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }


    // هاي الداله مسؤولة عن عرض المواد المتاحة 
    private void DisplayAvailableItems()
    {

        foreach (var item in items)
        {
            if (item.IsActive && item.IsAvailable == true)
            {

                string type = "";

                if (item is Book)
                    type = "Book";
                else if (item is Magazine)
                    type = "Magazine";
                else if (item is ResearchPaper)
                    type = "ResearchPaper";
                Console.WriteLine($"id:{item.Id} , title:{item.Title} , Type : [{type}]");
            }
        }
    }
 

//    داله مسؤولة عن عرض تفاصيل المادة 
private void ViewItemDetails()
{
    Console.WriteLine("Enter the subject ID.");
    int id = int.Parse(Console.ReadLine());

    bool found = false;
    
    foreach (var item in items)
    {
        if (item.CheckedId(id))
        {
            found = true;
            Console.WriteLine("------------------View Item Details------------------");
            Console.WriteLine($"ID: {item.Id}");
            Console.WriteLine($"Title: {item.Title}");
            Console.WriteLine($"Is Active: {item.IsActive}");
            Console.WriteLine($"Is Available: {item.IsAvailable}");
          if (item is Book book)
{
    Console.WriteLine($"Author: {book.Author}");
    Console.WriteLine($"Pages: {book.Pages}");
}

   if(item is Magazine magazine)
                {
                        Console.WriteLine($"IssueNumber: {magazine.IssueNumber}");
                }  

                   if(item is ResearchPaper researchPaper)
                {
                        Console.WriteLine($"Researcher: {researchPaper.Researcher}");
                         Console.WriteLine($"ResearchField: {researchPaper.ResearchField}");
                }  

            break;
        }
    }

    if (!found)
    {
        Console.WriteLine("Wrong ID. Item not found.");
    }
}


   
//    هاي الداله لتحديث البيانات 
private void EditItem()
{
    Console.WriteLine("Enter the item ID:");
    int id = int.Parse(Console.ReadLine());

    bool found = false;

    foreach (var item in items)
    {
        if (item.Id == id)
        {
            found = true;

            Console.WriteLine($"Current title: {item.Title}");
            Console.WriteLine("Enter the new title:");
            item.Title = Console.ReadLine();

            Console.WriteLine("Is the item available? (true/false)");
            item.IsAvailable = bool.Parse(Console.ReadLine());

            Console.WriteLine("Is the item active? (true/false)");
            item.IsActive = bool.Parse(Console.ReadLine());
            if (item is Book book)
{
    Console.WriteLine("Enter the new author:");
    book.Author = Console.ReadLine();

    Console.WriteLine("Enter the new number of pages:");
    book.Pages = int.Parse(Console.ReadLine());
}
else if (item is Magazine magazine)
{
    Console.WriteLine("Enter the new issue number:");
    magazine.IssueNumber = int.Parse(Console.ReadLine());
}
else if (item is ResearchPaper paper)
{
    Console.WriteLine("Enter the new researcher's name:");
    paper.Researcher = Console.ReadLine();

    Console.WriteLine("Enter the new research field:");
    paper.ResearchField = Console.ReadLine();
}

            Console.WriteLine("Item updated successfully!");
            break;
        }
    }

    if (!found)
    {
        Console.WriteLine("Item not found.");
    }
}




// الداله لتعطيل المادة 

private void DeactivateItem()
{
    Console.WriteLine("Enter the item ID:");
    int id = int.Parse(Console.ReadLine());

    bool found = false;

    foreach (var item in items)
    {
        if (item.Id == id)
        {
            found = true;

            if (!item.IsActive)
            {
                Console.WriteLine("This item is already deactivated.");
                break;
            }

            item.IsActive = false;
            item.IsAvailable = false;

            Console.WriteLine("Item deactivated successfully!");
            break;
        }
    }

    if (!found)
    {
        Console.WriteLine("Item not found.");
    }
}


// داله لتسجيل عضو جديد
private void RegisterNewMember()
    {
        int id = nextId++;
           bool exists = false;
        Console.WriteLine($"Your Id is :{id}");

         Console.WriteLine("Enter your Name");
         string name=Console.ReadLine();

         Console.WriteLine("Enter your Password");
         string password=Console.ReadLine();

         Console.WriteLine("Enter your PhoneNumber");
         string phoneNumber=Console.ReadLine();

          Console.WriteLine("Enter your Address");
         string address=Console.ReadLine();

            Console.WriteLine("Enter your MembershipId");
         int membershipId=int.Parse(Console.ReadLine());

         foreach (Person p in person)
{
    if (p is Member)
    {
        Member m = (Member)p;

        if (m.MembershipId == membershipId)
        {
            exists = true;
            break;
        }
    }
}

if (exists)
{
    Console.WriteLine("This Membership ID already exists!");
    return;
}

          Console.WriteLine("Enter your MaxLoanLimit");
         int maxLoanLimit=int.Parse(Console.ReadLine());


         Member member = new Member(id,name,password,phoneNumber,address,membershipId,maxLoanLimit);

person.Add(member);

    }


// داله لعرض جميع الاعضاء
private void ShowAllMembers()
    {
        if (person.Count == 0)
        {
            Console.WriteLine("No registered members.");
        }

        foreach(var p in person)
        {
            Console.WriteLine(p);
        }
    }

private void SearchMemberByMembershipId()
{
    Console.WriteLine("Enter Membership ID:");
    int membershipId = int.Parse(Console.ReadLine());

    bool found = false;

    foreach (Person p in person)
    {
        if (p is Member)
        {
            Member m = (Member)p;

            if (m.MembershipId == membershipId)
            {
                found = true;

                Console.WriteLine($"ID: {m.Id}");
                Console.WriteLine($"Name: {m.Name}");
                Console.WriteLine($"Membership ID: {m.MembershipId}");
                Console.WriteLine($"Phone: {m.PhoneNumber}");
                Console.WriteLine($"Address: {m.Address}");
                Console.WriteLine($"Max Loan Limit: {m.MaxLoanLimit}");

                break;
            }
        }
    }

    if (!found)
    {
        Console.WriteLine("Member not found.");
    }
}

// داله لعرض بيانات العضو وسجل استعاراته.
private void ViewMemberDetailsAndLoanHistory()
{
    Console.Write("Enter Membership ID: ");
    if (!int.TryParse(Console.ReadLine(), out int membershipId))
    {
        Console.WriteLine("Invalid Membership ID!");
        return;
    }

    Member member = null;

    foreach (Person p in person)
    {
        if (p is Member m && m.MembershipId == membershipId)
        {
            member = m;
            break;
        }
    }

    if (member == null)
    {
        Console.WriteLine("Member not found!");
        return;
    }

    Console.WriteLine("===== Member Details =====");
    Console.WriteLine($"ID: {member.Id}");
    Console.WriteLine($"Name: {member.Name}");
    Console.WriteLine($"Membership ID: {member.MembershipId}");
    Console.WriteLine($"Phone Number: {member.PhoneNumber}");
    Console.WriteLine($"Address: {member.Address}");
    Console.WriteLine($"Maximum Loan Limit: {member.MaxLoanLimit}");

    Console.WriteLine("===== Loan History =====");

    bool hasLoans = false;

    foreach (Loan loan in loans)
    {
        if (loan.MemberId == member.Id)
        {
            hasLoans = true;

            LibraryItem item = null;

            foreach (LibraryItem i in items)
            {
                if (i.Id == loan.ItemId)
                {
                    item = i;
                    break;
                }
            }

            Console.WriteLine("------------------------");
            Console.WriteLine($"Item ID: {loan.ItemId}");
            Console.WriteLine($"Title: {item?.Title ?? "Item no longer exists"}");
            Console.WriteLine($"Loan Date: {loan.LoanDate}");
            Console.WriteLine($"Expected Return Date: {loan.ExpectedReturnDate}");

            if (loan.ActualReturnDate.HasValue)
                Console.WriteLine($"Actual Return Date: {loan.ActualReturnDate.Value}");
            else
                Console.WriteLine("Status: Currently Borrowed");

            Console.WriteLine($"Fine Amount: {loan.FineAmount}");
        }
    }

    if (!hasLoans)
    {
        Console.WriteLine("This member has no loan history.");
    }
}



private void SetMaximumLoanLimit()
{
    Console.Write("Enter Membership ID: ");
     int membershipId = int.Parse(Console.ReadLine());
    if (membershipId <= 0 )
    {
        Console.WriteLine("Invalid Membership ID!");
        return;
    }

    Member member = null;

    foreach (Person p in person)
    {
        if (p is Member m && m.MembershipId == membershipId)
        {
            member = m;
            break;
        }
    }

    if (member == null)
    {
        Console.WriteLine("Member not found!");
        return;
    }

    Console.Write("Enter the new maximum loan limit: ");
     int limit=int.Parse(Console.ReadLine());

    if ( limit < 1)
    {
        Console.WriteLine("The limit must be a positive number!");
        return;
    }

    member.MaxLoanLimit = limit;

    Console.WriteLine(
        $"Maximum loan limit for {member.Name} updated to {member.MaxLoanLimit}.");
}

}

