using ConsoleApp8;

abstract class Member
{
    public string Name { get; set; }
    public string MemberID { get; set; }
    public abstract string MembershipType { get; }
    public abstract int BorrowLimit { get; }

    private List<Book> borrowedBooks = new List<Book>();

    public Member(string name, string memberId)
    {
        Name = name;
        MemberID = memberId;
    }

    public bool BorrowBook(Book book)
    {
        if (borrowedBooks.Count >= BorrowLimit)
        {
            Console.WriteLine($"{Name} cannot borrow more books. {MembershipType} limit reached: {BorrowLimit}.");
            return false;
        }

        else if (!book.Borrow())
        {
            Console.WriteLine($"{Name} cannot borrow \"{book.Title}\". No copies available.");
            return false;
        }

        else
        {
            borrowedBooks.Add(book);
            Console.WriteLine($"{Name} borrowed \"{book.Title}\". Books borrowed: {borrowedBooks.Count}/{BorrowLimit}.");
            return true;
        }
    }

    public void ReturnBook(Book book)
    {
        if (borrowedBooks.Remove(book))
        {
            book.Return();
            Console.WriteLine($"{Name} returned \"{book.Title}\". Copies available: {book.AvailableCopies}.");
        }
        else
        {
            Console.WriteLine($"{Name} does not have \"{book.Title}\" to return.");
        }
    }
}
class StudentMember : Member
{
    private const int borrowLimit = 5;
    public override int BorrowLimit
    {
        get { return borrowLimit; }
    }

    private string membershipType = "Student";
    public override string MembershipType
    { 
        get { return membershipType; } 
    }

    public StudentMember(string name, string memberId) : base(name, memberId) { }
}

class StaffMember : Member
{
    private const int borrowLimit = 10;
    public override int BorrowLimit
    {
        get { return borrowLimit; }
    }

    private string membershipType = "Staff";
    public override string MembershipType
    {
        get { return membershipType; }
    }

    public StaffMember(string name, string memberId) : base(name, memberId) { }
}
