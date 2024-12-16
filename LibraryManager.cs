using ConsoleApp8;

abstract class LibraryManagement
{
    public abstract void AddBook(Book book);
    public abstract void RemoveBook(Book book);
    public abstract void BorrowBook(Member member, Book book);
    public abstract void ReturnBook(Member member, Book book);
    public abstract void BookCount();
}

class Library : LibraryManagement
{
    private List<Book> books = new List<Book>();

    public override void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Added book: \"{book.Title}\" by {book.Author}.");
    }

    public override void RemoveBook(Book book)
    {
        if (books.Remove(book))
        {
            Console.WriteLine($"Removed book: \"{book.Title}\".");
        }
        else
        {
            Console.WriteLine($"Book \"{book.Title}\" not found in the library.");
        }
    }

    public override void BorrowBook(Member member, Book book)
    {
        if (books.Contains(book))
        {
            member.BorrowBook(book);
        }
        else
        {
            Console.WriteLine($"Book \"{book.Title}\" not available in the library.");
        }
    }

    public override void ReturnBook(Member member, Book book)
    {
        member.ReturnBook(book);
    }

    public override void BookCount()
    {
        Console.WriteLine($"Total available books: {books.Count}");
    }
}