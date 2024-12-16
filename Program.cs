using ConsoleApp8;

class Program
{
    static void Main()
    {
        Library library = new Library();

        Book book1 = new Book("C# in Depth", "Jon Skeet", "12345", 10);
        Book book2 = new Book("Clean Code", "Robert C. Martin", "67890", 10);

        Member meto = new StudentMember("Meto", "001");
        Member mitko = new StaffMember("Mitko", "002");
        Member nadezhda = new StudentMember("Nadezhda", "003");

        library.AddBook(book1);
        library.AddBook(book2);

        library.BorrowBook(meto, book1);
        library.BorrowBook(meto, book2);
        library.BorrowBook(meto, book2);
        library.BorrowBook(meto, book1);
        library.BorrowBook(meto, book2);
        library.BorrowBook(meto, book2);

        library.ReturnBook(mitko, book2);
        library.BorrowBook(mitko, book2);

        library.BorrowBook(nadezhda, book1);
        library.BorrowBook(nadezhda, book2);
        library.BorrowBook(nadezhda, book2);

        library.RemoveBook(book1);
        library.RemoveBook(book1);
        library.RemoveBook(book2);
        library.BookCount();
    }
}